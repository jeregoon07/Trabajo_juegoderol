using System;
using System.Collections.Generic;
using System.Reflection;

namespace Ucu.Poo.RolePlayGame
{
    public class EncuentroDeCombate : IEncuentro
    {
        private List<Heroe> heroes;
        private List<Enemigo> enemigos;

        public EncuentroDeCombate(List<Heroe> heroes, List<Enemigo> enemigos)
        {
            if (heroes == null)
            {
                throw new ArgumentNullException(nameof(heroes));
            }
            if (enemigos == null)
            {
                throw new ArgumentNullException(nameof(enemigos));
            }

            this.heroes = heroes;
            this.enemigos = enemigos;

            if (this.heroes.Count == 0 || this.enemigos.Count == 0)
            {
                throw new ArgumentException("Debe haber al menos un héroe y un enemigo.");
            }
        }

        public void DoEncounter()
        {
            while (HayHeroesVivos() && HayEnemigosVivos())
            {
                TurnoEnemigos();

                if (!HayHeroesVivos())
                {
                    break;
                }

                TurnoHeroes();
            }

            CurarHeroesConSuficientesVP();
        }

        private void TurnoEnemigos()
        {
            List<Heroe> heroesVivos = ObtenerHeroesVivos();
            List<Enemigo> enemigosVivos = ObtenerEnemigosVivos();

            for (int i = 0; i < enemigosVivos.Count; i++)
            {
                heroesVivos = ObtenerHeroesVivos();
                if (heroesVivos.Count == 0)
                {
                    break;
                }

                // Asignación circular de objetivos usando módulo (%)
                Heroe objetivo = heroesVivos[i % heroesVivos.Count];
                enemigosVivos[i].Atacar(objetivo,dañoBase:20);
            }
        }

        private void TurnoHeroes()
        {
            List<Heroe> heroesVivos = ObtenerHeroesVivos();

            foreach (Heroe heroe in heroesVivos)
            {
                if (heroe.VidaMaxima <= 0)
                {
                    continue;
                }

                List<Enemigo> enemigosVivos = ObtenerEnemigosVivos();
                foreach (Enemigo enemigo in enemigosVivos)
                {
                    // Cada héroe ataca al enemigo (ajusta según cómo implementes el ataque en tu juego)
                    heroe.Atacar(enemigo,dañoBase:20);

                    if (enemigo.VidaMaxima <= 0)
                    {
                        heroe.PuntosVictoria += enemigo.PuntosVictoria;
                    }
                }
            }
        }

        private void CurarHeroesConSuficientesVP()
        {
            foreach (Heroe heroe in this.heroes)
            {
                if (heroe.VidaMaxima > 0 && heroe.PuntosVictoria >= 5)
                {
                    heroe.Curarse();
                }
            }
        }

        private List<Heroe> ObtenerHeroesVivos()
        {
            List<Heroe> lista = new List<Heroe>();
            foreach (Heroe h in this.heroes)
            {
                if (h.VidaMaxima > 0)
                {
                    lista.Add(h);
                }
            }
            return lista;
        }

        private List<Enemigo> ObtenerEnemigosVivos()
        {
            List<Enemigo> lista = new List<Enemigo>();
            foreach (Enemigo e in this.enemigos)
            {
                if (e.VidaMaxima > 0)
                {
                    lista.Add(e);
                }
            }
            return lista;
        }

        private bool HayHeroesVivos()
        {
            foreach (Heroe h in this.heroes)
            {
                if (h.VidaMaxima > 0)
                {
                    return true;
                }
            }
            return false;
        }

        private bool HayEnemigosVivos()
        {
            foreach (Enemigo e in this.enemigos)
            {
                if (e.VidaMaxima > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}