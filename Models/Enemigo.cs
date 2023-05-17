using SpaceInvaders.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Models;

public abstract class Enemigo
{
    public PictureBox pbEnemigo;
    public int Vida { get; set; }
    public int MovX, MovY;

    private Thread muertoThread;

    protected bool muerto { get; set; } = false;
    public Image ?Image { get; set; }
    public Point Location { get; set; }
    private Point Desde, Hasta;
    public Size Size { get; set; }
    public Rectangle Bounds { get; set; }
    public double ProbabilidadDeAtacar { get; set; }
    public int ProbabilidadDeDrop { get; set; }
    public List<Mejora> Mejoras { get; set; }
    private Mejora? mejora;
    public Enemigo(int vida, Point loc, Size s, PictureBox pb, double prob, Point desde, Point hasta, int movX, int movY, int probabilidadDeDrop = 0)
    {
        pb.Location = loc;
        pb.Size = s;
        pb.SizeMode = PictureBoxSizeMode.StretchImage;
        pb.BackColor = Color.Transparent;
        pbEnemigo = pb;
        ProbabilidadDeAtacar = prob;
        MovX = movX;
        MovY = movY;
        Desde = desde;
        Hasta = hasta;
        Vida = vida;
        Location = loc;
        Size = s;
        Bounds = new(Location, Size);
        muertoThread = new(() => Muerto());
        ProbabilidadDeDrop = probabilidadDeDrop;
        Point pos = new(Location.X + Size.Width / 2, Location.Y + Size.Height);
        Mejoras = new()
        {
            new MejoraAtaque(pos),
            new MejoraEscudo(pos),
            new MejoraAtaque(pos),
            new MejoraInvencibilidad(pos),
            new MejoraEscudo(pos)
        };
    }

    public void Mover()
    {
        pbEnemigo.Top += MovY;
        pbEnemigo.Left += MovX;
        if (pbEnemigo.Location.X == Desde.X || pbEnemigo.Location.X == Hasta.X)
        {
            MovX = -MovX;
        }
        if (pbEnemigo.Location.Y == Desde.Y || pbEnemigo.Location.Y == Hasta.Y)
        {
            MovY = -MovY;
        }
        Bounds = new(pbEnemigo.Location, Size);
    }

    private void Muerto()
    {
        pbEnemigo.Image = Resources.EnemyDeath1;
        Thread.Sleep(250);
        pbEnemigo.Image = Resources.EnemyDeath2;
        Thread.Sleep(250);
        pbEnemigo.Image = null;
    }

    public ProyectilEnemigo Atacar()
    {
        Point pos = new(Location.X + Size.Width / 2, Location.Y + Size.Height);
        ProyectilEnemigo proyectil = new(pos);
        return proyectil;
    }

    public void TakeDamage(int Ataque)
    {
        Vida -= Ataque;
        if (Vida <= 0)
        {
            muerto = true;
            DropMejora();
            muertoThread.Start();
        }
    }

    public Mejora? GetMejora() 
    {
        return mejora;
    }

    public void DropMejora()
    {
        Random rng = new();
        if (ProbabilidadDeDrop > rng.Next(100))
        {
            mejora = Mejoras[rng.Next(Mejoras.Count)];
        }
    }

    public bool IsDeath()
    {
        return muerto;
    }

}
