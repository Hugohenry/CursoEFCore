using Curso.Domain;
using System;
using Curso.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Curso.CursoEFCore
{
    class Program
    {
        private static void Main(string[] args)
        {
            //InserirDados();
            //InserirDados2();
            //InserirDadosEmMassa();
            ConsultarDados();
        }

        /* private static void InserirDadosEmMassa()
         {
             var produto = new Produto
             {
                 Descricao = "ProdutoTeste2",
                 CodigoBarra = "99876768",
                 Valor = 20m,
                 TipoProduto = TipoProduto.MercadoriParaRevenda,
                 Ativo = true
             };

             var cliente = new Cliente
             {
                 Nome = "Hugo",
                 Telefone = "76555679",
                 Cep = "97856565",
                 Cidade = "Recife",
                 Estado = "PE"
             };

             using var db = new Data.ApplicationContext();
             db.AddRange(produto, cliente);

             var registros = db.SaveChanges();
             Console.WriteLine($"Total Registro(s): {registros}");

         }*/

        private static void InserirDados()
        {
            var produto = new Produto
            {
                Descricao = "teste 2304",
                CodigoBarra = "8888885897866",
                Valor = 10m,
                TipoProduto = TipoProduto.MercadoriParaRevenda,
                Ativo = true
            };

            using var db = new Data.ApplicationContext();

            //db.Produtos.Add(produto);
            //db.Set<Produto>().Add(produto);
            //db.Entry(produto).State = EntityState.Added;
            db.Add(produto);

            var registros = db.SaveChanges();
            Console.WriteLine($"Total Registro(s): {registros}");
        }

        /*private static void InserirDados2()
        {
            var cliente = new Cliente
            {
                Nome = "Hugo",
                Telefone = "76555679",
                Cep = "97856565",
                Cidade = "Recife",
                Estado = "PE",
                Email = "hugohenry57",
                Sexo = "Masculino"
            };

            using var db = new Data.ApplicationContext();

            //db.Produtos.Add(produto);
            //db.Set<Produto>().Add(produto);
            //db.Entry(produto).State = EntityState.Added;
            db.Add(cliente);

            var registros = db.SaveChanges();
            Console.WriteLine($"Total Registro(s): {registros}");
        }                 
        
        
        
        */

        private static void ConsultarDados()
        {
            using var db = new Data.ApplicationContext();
            //var consultarPorSintaxe = (from c in db.Clientes where c.Id > 0 select c).ToList();
            var consultaPorMetodo = db.Clientes.Where(p => p.Id > 0).ToList();
            foreach (var cliente in consultaPorMetodo)
            {
                Console.WriteLine($"Consulta Cliente: {cliente.Id}");
                //db.Clientes.Find(cliente.Id);
                db.Clientes.FirstOrDefault(p => p.Id == cliente.Id);

            }
        }




    }
}
