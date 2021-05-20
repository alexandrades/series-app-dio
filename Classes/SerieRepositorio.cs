using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series.Classes
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();

        public void Atualiza(int id, Serie serie)
        {
            listaSerie[id] = serie;
        }

        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Insere(Serie serie)
        {
            listaSerie.Add(serie);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}