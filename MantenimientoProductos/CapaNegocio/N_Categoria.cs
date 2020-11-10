using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;
namespace CapaNegocio
{
    public class N_Categoria
    {
        D_Categoria objDato = new D_Categoria();

        public List<E_Categoria> ListandoCategoria(string buscar)
        {
            return objDato.ListarCategorias(buscar);
        }
        public void InsertandoCategoria(E_Categoria categoria)
        {
            objDato.InsertarCategoria(categoria);
        }

        public void EditandoCategoria(E_Categoria categoria)
        {
            objDato.EditarCategoria(categoria);
        }

        public void EliminandoCategoria(E_Categoria categoria)
        {
            objDato.EliminarCategoria(categoria);
        }
    }
}
