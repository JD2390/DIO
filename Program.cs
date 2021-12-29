using System;

namespace DIO
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            // int numerolaco =5;
            // for (int i = 0; i < numerolaco; i++)
            // {
            //     Console.WriteLine($"Bem Vindo ao Curso .Net v {i}");
            // }
            Aluno[] alunos = new Aluno[5];
            int inAluno=0;
            string opcaoUsuario= ObterOpcao();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                    //adicionar
                    Console.WriteLine("Informa o nome do aluno: ");
                    Aluno aluno = new Aluno();
                    aluno.Nome = Console.ReadLine();

                    Console.WriteLine("Informa a nota do aluno: ");
                    
                    if (decimal.TryParse(Console.ReadLine(), out decimal nota)){
                        aluno.Nota=nota;
                    }else
                    {
                        throw new ArgumentException("Valor da nota tem que ser decimal");
                    }

                    alunos[inAluno]=aluno;
                    inAluno++;

                    break;

                    case "2":
                    //listar
                    foreach (var a in alunos)
                    {
                        if (!string.IsNullOrEmpty(a.Nome))
                        {
                            Console.WriteLine($"Aluno: {a.Nome} - Nota:{a.Nota}");
                        }
                        
                    }
                    if (alunos.Length==0)
                    {
                        Console.WriteLine("Não existe aluno para listar.");
                    }
                    break;

                    case "3":
                    //calcular
                    decimal notaTotal =0;
                    var nAlunos=0;

                    for (int i = 0; i < alunos.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(alunos[i].Nome))
                        {
                            notaTotal+=alunos[i].Nota;
                            nAlunos++;
                        }
                    }
                    if (nAlunos!=0)
                    {
                        var mediaGeral = notaTotal/nAlunos;
                        Conceito conceitogeral;
                        
                        if (mediaGeral<=2)
                        {
                            conceitogeral=Conceito.E;
                        }else if(mediaGeral<=4)
                        {
                            conceitogeral=Conceito.D;
                        }else if(mediaGeral<=6)
                        {
                            conceitogeral=Conceito.C;
                        }else if(mediaGeral<=8)
                        {
                            conceitogeral=Conceito.B;
                        }else
                        {
                            conceitogeral=Conceito.A;
                        }

                        Console.WriteLine($"A média dos alunos é: {mediaGeral} - Conceito: {conceitogeral}");
                    }else
                    {
                        Console.WriteLine("Não existe alunos para obter média.");
                    }
                    
                    break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcao();
            }
            
        }

        private static string ObterOpcao(){
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("x- Sair");
            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
