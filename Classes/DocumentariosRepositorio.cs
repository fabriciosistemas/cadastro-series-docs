using System;
using System.Collections.Generic;
using DIO.Docs.Interfaces;

namespace DIO.Docs
{
    public class DocumentariosRepositorio : IRepositorioDocs<Documentarios>
    {
        private List<Documentarios> listaDocs = new List<Documentarios>();
		public void Atualiza(int id, Documentarios objeto)
		{
			listaDocs[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaDocs[id].Excluir();
		}

		public void Insere(Documentarios objeto)
		{
			listaDocs.Add(objeto);
		}

		public List<Documentarios> Lista()
		{
			return listaDocs;
		}

		public int ProximoId()
		{
			return listaDocs.Count;
		}

		public Documentarios RetornaPorId(int id)
		{
			return listaDocs[id];
		}
    }
}