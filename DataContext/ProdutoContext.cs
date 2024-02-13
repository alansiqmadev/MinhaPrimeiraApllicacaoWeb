using Microsoft.EntityFrameworkCore;
using System; 
using MinhaPrimeiraAplicacaoWeb.Models;

namespace MinhaPrimeiraAplicacaoWeb.DataContext;

public class ProdutoContext:DbContext{

    public DbSet<ProdutoModel> Produtos {get;set;}

    public ProdutoContext(DbContextOptions<ProdutoContext> options):base(options)
    {  
    }
}