using SpaceInvaders.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Models
{

    public class Nave
    {
        public PictureBox pbNave { get; set; }
        public int Vida { get; set; }
        public bool Invulnerable { get; set; }
        public Image CurrentImage { get; set; }
        public bool EscudoActivo { get; set; }
        public bool Muerto { get; set; }
        public int Ataque { get; set; }
        public Thread invulnerabilidadTimer;

        public Nave()
        {
            CurrentImage = Resources.MainShipFullHealth;
            pbNave = new();
            Vida = 5;
            Invulnerable = false;
            EscudoActivo = false;
            Muerto = false;
            Ataque = 1;
            invulnerabilidadTimer = new( () => InvulnerableTimer());
        }

        public void MejoraAtaque()
        {
            Ataque++;
        }

        public void InvulnerableTimer()
        {
            Thread.Sleep(5000);
            HacerVulnerable();
        }

        public void HacerInvulnerable()
        {
            if (!Invulnerable)
            {
                invulnerabilidadTimer = new(() => InvulnerableTimer());
                invulnerabilidadTimer.Start();
                Invulnerable = true;
                UpdateImage();
            }
        }

        private void HacerVulnerable()
        {
            Invulnerable = false;
            UpdateImage();
        }

        public void ActivarEscudo()
        {
            EscudoActivo = true;
            pbNave.Image = Resources.Shield;
        }

        public void DesactivarEscudo()
        {
            EscudoActivo = false;
            UpdateImage();
        }

        public void SetPictureBox(PictureBox pb)
        {
            pbNave = pb;
            UpdateImage();
        }

        public bool IsDeath()
        {
            return Muerto;
        }

        public void TakeDamage()
        {
            if (EscudoActivo)
            {
                DesactivarEscudo();
            }
            else
            {
                if (!Invulnerable)
                {
                    UpdateVida(-1);
                    Ataque-= 2;
                    if (Ataque <=0)
                    {
                        Ataque = 1;
                    }
                    HacerInvulnerable();
                }
            }
        }

        public void UpdateVida(int delta)
        {
            Vida += delta;
            switch (Vida) 
            {
                case 0:
                    Muerto = true;
                    break;
                case 1:
                    CurrentImage = Resources.MainShipVeryDamaged;
                    break;
                case 2:
                    CurrentImage = Resources.MainShipDamaged;
                    break;
                case 3:
                    CurrentImage = Resources.MainShipSlightDamage;
                    break;
                default:
                    CurrentImage = Resources.MainShipFullHealth;
                    break;
            }
            UpdateImage();
        }

        public void UpdateImage()
        {
            pbNave.Image = CurrentImage;
            if (Invulnerable)
            {
                pbNave.Image = Resources.Invencibilidad;
            }
            if (EscudoActivo)
            {
                pbNave.Image = Resources.Shield;
            }
        }
    }
}
