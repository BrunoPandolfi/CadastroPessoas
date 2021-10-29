using CadastroPessoas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroPessoas.Data
{
    public class SeedingService
    {
        private readonly CadastroPessoasContext _context;

        public SeedingService(CadastroPessoasContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Pessoa.Any())
            {
                return;
            }

            Pessoa p1 = new Pessoa(1, "João Silva", "13212635483", new DateTime(1970, 9, 6), "joão@gmail.com", null);
            Pessoa p2 = new Pessoa(2, "Maria Souza", "84756525456", new DateTime(1990, 4, 14), "maria@gmail.com", null);
            Pessoa p3 = new Pessoa(3, "José Ferreira", "32546525465", new DateTime(2000, 10, 6), "josé@gmail.com", null);
            Pessoa p4= new Pessoa(4, "Marta Fernandes", "10245698785", new DateTime(1993, 1, 27), "marta@gmail.com", null);
            Pessoa p5 = new Pessoa(5, "Fátima Marques", "13212635483", new DateTime(1981, 2, 4), "fatima@gmail.com", null);
            Pessoa p6 = new Pessoa(6, "John Matos", "13212635483", new DateTime(2005, 8, 30), "john@gmail.com", null);
            Pessoa p7 = new Pessoa(7, "João das Neves", "90032343209", new DateTime(1990, 3, 9), "joão.neves@gmail.com", null);
            Pessoa p8 = new Pessoa(8, "Maria Silva", "32130930493", new DateTime(1987, 5, 2), "maria.silva@gmail.com", null);
            Pessoa p9 = new Pessoa(9, "João Lima", "09321345203", new DateTime(1986, 3, 15), "joão.lima@gmail.com", null);
            Pessoa p10 = new Pessoa(10, "Roberto Souza", "54343203909", new DateTime(1999, 4, 8), "roberto@gmail.com", null);
            Pessoa p11 = new Pessoa(11, "Eduardo Silva", "12309434954", new DateTime(1997, 12, 14), "eduardo@gmail.com", null);
            Pessoa p12 = new Pessoa(12, "José Santos", "09312909320", new DateTime(2008, 2, 10), "josé.santos@gmail.com", null);
            Pessoa p13 = new Pessoa(13, "Jean Ferreira", "87430932103", new DateTime(2003, 11, 8), "jean@gmail.com", null);
            Pessoa p14 = new Pessoa(14, "Marta Rocha", "03320020039", new DateTime(1980, 7, 18), "marta.rocha@gmail.com", null);
            Pessoa p15 = new Pessoa(15, "Ada Lovelace", "94332109308", new DateTime(1995, 12, 6), "ada@gmail.com", null);

            _context.Pessoa.AddRange(p1, p2, p3, p4, p5, p6, p7, p8, p9,
                                     p10, p11, p12, p13, p14, p15);
            _context.SaveChangesAsync();
        }
    }
}
