using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboNET
{
    class Execução
    {
        static void Main(string[] args)
        {
  
            string inicio = "";
            string movimento = "";

            Console.WriteLine("Área do grid (exemplo: 5 4): ");
            string grid = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("\nDigite a posição inicial do robô:");
                inicio = Console.ReadLine();
                Robo robo = new Robo(grid, inicio);

                Console.WriteLine("\nDigite o movimento do robô:");
                movimento = Console.ReadLine();
                robo.Mover(movimento);

                robo.MostrarPosicao();
            }
        }
    }

    class Robo
    {
        string grid = "", sentido = "", inicio = "";
        int x, y;
        string[] coordenadasGrid, coordenadasRobo;

        public Robo(string grid, string inicio)
        {
            this.inicio = inicio;
            this.grid = grid;
        }

        public void Mover(string movimento)
        {
            PosicionarRobo();

            for (int i = 0; i < movimento.Length; i++)
            {
                if (movimento[i].Equals('E') || movimento[i].Equals('e'))
                    MoverParaEsquerda();

                else if (movimento[i].Equals('D') || movimento[i].Equals('d'))
                    MoverParaDireita();

                else if (movimento[i].Equals('M') || movimento[i].Equals('m'))
                    MoverParaFrente();
            }
        }

        public void PosicionarRobo()
        {
            coordenadasGrid = grid.Split(' ');
            coordenadasRobo = inicio.Split(' ');

            this.x = Int16.Parse(coordenadasRobo[0]);
            this.y = Int16.Parse(coordenadasRobo[1]);
            this.sentido = coordenadasRobo[2];
        }

        public void MoverParaEsquerda()
        {
            if (this.sentido.Equals("n", StringComparison.OrdinalIgnoreCase))
                this.sentido = "O";

            else if (this.sentido.Equals("o", StringComparison.OrdinalIgnoreCase))
                this.sentido = "S";

            else if (this.sentido.Equals("s", StringComparison.OrdinalIgnoreCase))
                this.sentido = "L";

            else if (this.sentido.Equals("l", StringComparison.OrdinalIgnoreCase))
                this.sentido = "N";
        }

        public void MoverParaDireita()
        {
            if (this.sentido.Equals("n", StringComparison.OrdinalIgnoreCase))
                this.sentido = "L";

            else if (this.sentido.Equals("o", StringComparison.OrdinalIgnoreCase))
                this.sentido = "N";

            else if (this.sentido.Equals("s", StringComparison.OrdinalIgnoreCase))
                this.sentido = "O";

            else if (this.sentido.Equals("l", StringComparison.OrdinalIgnoreCase))
                this.sentido = "S";
        }

        public void MoverParaFrente()
        {
            if (this.sentido.Equals("n", StringComparison.OrdinalIgnoreCase))
                this.y++;

            if (this.sentido.Equals("s", StringComparison.OrdinalIgnoreCase))
                this.y--;

            if (this.sentido.Equals("l", StringComparison.OrdinalIgnoreCase))
                this.x++;

            if (this.sentido.Equals("o", StringComparison.OrdinalIgnoreCase))
                this.x--;
        }

        public void MostrarPosicao()
        {
            Console.WriteLine($"Posição após movimento: {this.x.ToString()} {this.y.ToString()} {this.sentido.ToString()}");
        }
    }
}
