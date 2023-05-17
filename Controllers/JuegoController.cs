using SpaceInvaders.Levels;
using SpaceInvaders.Models;
using SpaceInvaders.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace SpaceInvaders.Controllers
{
    public class JuegoController
    {
        public List<Enemigo> enemigos;
        public List<Proyectil> proyectiles;
        public PictureBox pbNave;
        private Thread? moverProyectilesThread, cooldownThread, moverEnemigosThread, moverMejoraThread;
        private CancellationTokenSource juegoTokenSource;
        private bool ataqueEnCooldown = false;
        private readonly Random rmEnemy = new();
        private Form form;
        private PictureBox pbVidas;
        private Label lblVidas;
        private Label lblFuerza;
        private Label lblScore;
        private PictureBox pbFuerza;
        private WMPLib.WindowsMediaPlayer player;
        private SoundPlayer playerDisparar;
        public JuegoController(List<Enemigo> enemigos, List<Proyectil> proyectiles, PictureBox pbNave, Form form)
        {
            this.form = form;
            player = new WMPLib.WindowsMediaPlayer();
            string relativePath = @"..\..\..\Resources\Voxel Revolution.mp3";
            string absolutePath = Path.GetFullPath(relativePath);
            player.URL = absolutePath;
            playerDisparar = new(Resources.Shoot);
            player.settings.setMode("loop", true);
            player.controls.play();
            player.settings.volume = 75;
            Program.nave.SetPictureBox(pbNave);
            pbVidas = new PictureBox();
            lblVidas = new Label();
            lblFuerza = new Label();
            lblScore = new Label();
            pbFuerza = new PictureBox();
            InicializarComponentes();
            ActualizarLabels();
            System.Windows.Forms.Timer ataqueTimer = new()
            {
                Interval = 3000
            };
            this.enemigos = enemigos;
            this.proyectiles = proyectiles;
            this.pbNave = pbNave;
            pbNave.BringToFront();
            this.pbNave.Enabled = false;
            juegoTokenSource = new();
            cooldownThread = new(() => Cooldown());
            moverEnemigosThread = new(()=>MoverEnemigos(juegoTokenSource.Token));
            Program.nave.HacerInvulnerable();
            moverEnemigosThread.Start();
            form.MouseMove += Form_MouseMove;
            form.FormClosed += Form_FormClosed;
            form.MouseClick += Form_MouseClick;
            ataqueTimer.Tick += AtaqueEnemigo_Tick;
            ataqueTimer.Start();
        }

        public void InicializarComponentes()
        {
            form.SuspendLayout();
            // 
            // pbVidas
            // 
            pbVidas.BackColor = Color.Transparent;
            pbVidas.Image = Resources.vida;
            pbVidas.Location = new Point(12, 12);
            pbVidas.Name = "pbVidas";
            pbVidas.Size = new Size(30, 30);
            pbVidas.SizeMode = PictureBoxSizeMode.StretchImage;
            pbVidas.TabIndex = 2;
            pbVidas.TabStop = false;
            // 
            // lblVidas
            // 
            lblVidas.AutoSize = true;
            lblVidas.BackColor = Color.Transparent;
            lblVidas.ForeColor = Color.FromArgb(224, 224, 224);
            lblVidas.Location = new Point(45, 20);
            lblVidas.Name = "lblVidas";
            lblVidas.Size = new Size(19, 15);
            lblVidas.TabIndex = 3;
            lblVidas.Text = "x5";
            // 
            // lblFuerza
            // 
            lblFuerza.AutoSize = true;
            lblFuerza.BackColor = Color.Transparent;
            lblFuerza.ForeColor = Color.FromArgb(224, 224, 224);
            lblFuerza.Location = new Point(103, 20);
            lblFuerza.Name = "lblFuerza";
            lblFuerza.Size = new Size(19, 15);
            lblFuerza.TabIndex = 5;
            lblFuerza.Text = "x1";
            // 
            // pbFuerza
            // 
            pbFuerza.BackColor = Color.Transparent;
            pbFuerza.Image = Resources.espada;
            pbFuerza.Location = new Point(70, 12);
            pbFuerza.Name = "pbFuerza";
            pbFuerza.Size = new Size(30, 30);
            pbFuerza.SizeMode = PictureBoxSizeMode.StretchImage;
            pbFuerza.TabIndex = 4;
            pbFuerza.TabStop = false;
            //
            // lblScore
            //
            lblScore.AutoSize = true;
            lblScore.BackColor = Color.Transparent;
            lblScore.ForeColor = Color.White;
            lblScore.Location = new Point(770, 9);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(102, 15);
            lblScore.TabIndex = 1;
            lblScore.Text = "Score: 0";

            form.Controls.Add(lblFuerza);
            form.Controls.Add(pbFuerza);
            form.Controls.Add(lblVidas);
            form.Controls.Add(pbVidas);
            form.Controls.Add(lblScore);
            form.ResumeLayout(false);
            form.PerformLayout();
        }
        
        public void ActualizarLabels()
        {
            lblFuerza.Text = $"x{Program.nave.Ataque}";
            lblVidas.Text = $"x{Program.nave.Vida}";
            lblScore.Text = $"Score: {Program.nave.Score}";
        }
        public bool HayColision(Rectangle objeto1, Rectangle objeto2)
        {
            return objeto1.IntersectsWith(objeto2);
        }

        public void Ganar()
        {
            MessageBox.Show("Has ganado uwu");
            player.controls.stop();
            form.Invoke((MethodInvoker)delegate {
                if (form is FormLevel1)
                {
                    Program.level = new FormLevel2();
                    Program.level.Show();
                }
                else if (form is FormLevel2)
                {
                    Program.level = new FormLevel3();
                    Program.level.Show();
                }
                else if (form is FormLevel3)
                {
                    Program.level = new FormLevel4();
                    Program.level.Show();
                }
                else if (form is FormLevel4)
                {
                    Program.level = new FormLevel5();
                    Program.level.Show();
                }
                else if (form is FormLevel5)
                {
                    Program.menu.Show();
                }
                form.Hide();
            });
            juegoTokenSource.Cancel();
        }

        public void Perder()
        {
            player.controls.stop();
            MessageBox.Show("Has perdido unu");
            form.Hide();
            Program.level = null;
            form.Dispose();
            Program.menu.Show();
        }

        #region Threads

        public void MoverEnemigos(CancellationToken token)
        {
            List<Enemigo> enemigos = new (this.enemigos);
            do
            {
                form.SuspendLayout();
                foreach (Enemigo enemigo in enemigos)
                {
                    if (!enemigo.IsDeath())
                    {
                        if (HayColision(enemigo.Bounds, pbNave.Bounds))
                        {
                            Program.nave.TakeDamage();
                            ActualizarLabels();
                            if (Program.nave.IsDeath())
                            {
                                Perder();
                            }
                        }
                        enemigo.Mover();
                    }
                    
                }
                form.ResumeLayout(false);
                Thread.Sleep(250);
                Application.DoEvents();
            }while (!token.IsCancellationRequested);
        }
        public void MoverMejora(Mejora mejora, CancellationToken token)
        {
            do
            {
                mejora.Mover();
                if (HayColision(mejora.PbMejora.Bounds, pbNave.Bounds))
                {
                    mejora.Activar(Program.nave);
                    ActualizarLabels();
                    RemovePb(mejora.PbMejora);
                    return;
                }
                Thread.Sleep(16);
            } while (!token.IsCancellationRequested);
        }
        public void MoverProyectiles(CancellationToken token, Proyectil proyectil)
        {
            PictureBox pbProyectil = proyectil.GetPictureBox();
            do
            {
                form.SuspendLayout();
                proyectil.Mover();
                form.ResumeLayout(false);
                form.PerformLayout();
                if (proyectil is ProyectilNave)
                {
                    foreach (Enemigo enemigo in enemigos)
                    {
                        if (!enemigo.IsDeath())
                        {
                            if (HayColision(enemigo.Bounds, pbProyectil.Bounds))
                            {
                                enemigo.TakeDamage(Program.nave.Ataque);
                                RemovePb(pbProyectil);
                                if (enemigo.IsDeath())
                                {
                                    Program.nave.UpdateScore(enemigo.Puntos);
                                    ActualizarLabels();
                                    enemigos.Remove(enemigo);
                                    Mejora? mejora = enemigo.GetMejora();
                                    if (mejora != null)
                                    {
                                        form.Invoke((Action)(() => {
                                            form.Controls.Add(mejora.PbMejora);
                                        }));
                                        moverMejoraThread = new(() => MoverMejora(mejora, juegoTokenSource.Token));
                                        moverMejoraThread.Start();
                                    }
                                    if (enemigos.Count == 0)
                                    {
                                        Ganar();
                                    }
                                    Thread.Sleep(500);
                                    enemigo.pbEnemigo.Visible = false;

                                }
                                return;
                            }
                        }
                    }
                }
                else
                {
                    if (HayColision(pbNave.Bounds, pbProyectil.Bounds))
                    {
                        if (!Program.nave.IsDeath())
                        {
                            RemovePb(pbProyectil);
                            Program.nave.TakeDamage();
                            ActualizarLabels();
                            if (Program.nave.IsDeath())
                            {
                                Perder();
                            }
                        }
                        return;
                    }
                }
                if (pbProyectil.Top < 0 || pbProyectil.Top > form.ClientSize.Height)
                {
                    RemovePb(pbProyectil);
                    proyectiles.Remove(proyectil);
                    return;
                }
                Thread.Sleep(16);
            } while (!token.IsCancellationRequested);
        }

        private void RemovePb(PictureBox pb)
        {
            form.Controls.Remove(pb);
            pb.Dispose();
        }
        public void Cooldown()
        {
            Thread.Sleep(175);
            ataqueEnCooldown = false;
        }
        #endregion

        #region Events
        public void Form_MouseMove(object? sender, MouseEventArgs e)
        {
            pbNave.Location = new(e.X - (pbNave.Width / 2), e.Y - (pbNave.Height / 2));
        }

        public void AtaqueEnemigo_Tick(object? sender, EventArgs e)
        {
            double numAleatorio;
            foreach (Enemigo enemigo in enemigos)
            {
                numAleatorio = rmEnemy.NextDouble();
                if (numAleatorio < enemigo.ProbabilidadDeAtacar && !enemigo.IsDeath())
                {
                    ProyectilEnemigo proyectil = enemigo.Atacar();
                    form.Controls.Add(proyectil.GetPictureBox()); 
                    proyectil.GetPictureBox().BringToFront();
                    moverProyectilesThread = new(() => MoverProyectiles(juegoTokenSource.Token, proyectil));
                    moverProyectilesThread.Start();
                }
            }
            
        }

        public void Form_MouseClick(object? sender, MouseEventArgs e)
        {

            if (!ataqueEnCooldown && e.Button == MouseButtons.Left)
            {
                Point pos = new(pbNave.Location.X + (pbNave.Width / 2), pbNave.Location.Y);
                ProyectilNave proyectil = new(pos);
                playerDisparar.Play();
                proyectiles.Add(proyectil);
                form.Controls.Add(proyectil.GetPictureBox());
                ataqueEnCooldown = true;
                cooldownThread = new(() => Cooldown());
                cooldownThread.Start();
                moverProyectilesThread = new(() => MoverProyectiles(juegoTokenSource.Token, proyectil));
                moverProyectilesThread.Start();
            }
        }

        public void Form_FormClosed(object? sender, FormClosedEventArgs e)
        {
            juegoTokenSource.Cancel();
            player.controls.stop();
            Application.Exit();
        }
        #endregion
    }
}
