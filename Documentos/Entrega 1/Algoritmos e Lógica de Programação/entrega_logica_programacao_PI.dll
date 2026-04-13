public class Program
{
    static void Main()
    {   
        string init;

        do {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("|                                   |");
            Console.WriteLine("|              Lab Game             |");
            Console.WriteLine("|                                   |");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("|        Digite 1 para iniciar      |");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("|         Digite 2 para sair        |");
            Console.WriteLine("-------------------------------------");
            init = Console.ReadLine();
        } while (init != "2" && init != "1");

        if(init == "1"){
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("|     VOCÊ DORMIU DEMAIS NA AULA E AGORA ESTA PRESO NA SALA    |"); 
            Console.WriteLine("|                     -Agora são 03:00 AM-                     |"); 
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Aperte enter para continuar");
            Console.ReadLine();
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                  Por algum motivo, na porta há 3 trancas para chaves diferentes.                      |");
            Console.WriteLine("|   Para adquirir cada chave, você deverá acertar 3 perguntas sobre programação de forma consecutiva.   |");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Aperte enter para continuar ou digite 1 para esperar que alguém abra a porta no dia seguinte.");
            string choice = Console.ReadLine();

            Random numGenerator = new Random();
            float life = 100f;
            string answer = "";
            int acertos = 0;
            int questao = 1;

            if (choice == "1")
            {
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("|         Você resolveu dormir novamente e esperar até que alguém abra a portano dia seguinte... (-_-) zzz         |");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            } else {
                while(acertos < 3 && life > 0)
                {
                    int numQuestions = numGenerator.Next(1, 5);
                    switch (numQuestions)
                    {
                        case 1:
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("| "+ questao + " O que é uma variável na programação? |");
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("A. Um comando exclusivo para desligar o programa.");
                            Console.WriteLine("B. Um espaço reservado na memória do computador para guardar uma informação temporária.");
                            Console.WriteLine("C. Um erro de lógica que faz o código travar.");
                            Console.WriteLine("D. Uma ferramenta de hardware conectada ao Visual Studio.");
                            answer = Console.ReadLine();
                            
                            if (answer == "B" || answer == "b")
                            {
                                acertos++;
                                Console.WriteLine("Resposta correta. " + acertos + " respostas certas consecutivas " + "Vida restante: " + life);
                            } else {
                                acertos = 0;
                                life = life - 100 * 1/4;
                                Console.WriteLine("Resposta incorreta. " + acertos + " respostas certas consecutivas " + "Vida restante: " + life);
                            }
                            questao++;
                            break;
                        case 2:
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("| "+ questao + " Qual a diferença principal entre os tipos int e string? |");
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("A. int guarda textos curtos e string guarda textos longos.");
                            Console.WriteLine("B. Não há diferença, ambos guardam qualquer tipo de dado.");
                            Console.WriteLine("C. int guarda números inteiros (para cálculos) e string guarda textos.");
                            Console.WriteLine("D. int guarda números com vírgula e string guarda números inteiros.");
                            answer = Console.ReadLine();
                            
                            if (answer == "C" || answer == "c")
                            {
                                acertos++;
                                Console.WriteLine("Resposta correta. " + acertos + " respostas certas consecutivas " + "Vida restante: " + life);
                            } else {
                                acertos = 0;
                                life = life - 100 * 1/4;
                                Console.WriteLine("Resposta incorreta. " + acertos + " respostas certas consecutivas " + "Vida restante: " + life);
                            }
                            questao++;
                            break;
                        case 3:
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("| "+ questao + " Para que serve a estrutura condicional if? |");
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("A. Para declarar uma nova variável no sistema.");
                            Console.WriteLine("B. Para repetir um código para sempre.");
                            Console.WriteLine("C. Para tomar decisões: o código dentro dele só roda se a condição for verdadeira.");
                            Console.WriteLine("D. Para fechar o Visual Studio Code automaticamente.");
                            answer = Console.ReadLine();
                            
                            if (answer == "C" || answer == "c")
                            {
                                acertos++;
                                Console.WriteLine("Resposta correta. " + acertos + " respostas certas consecutivas " + "Vida restante: " + life);
                            } else {
                                acertos = 0;
                                life = life - 100 * 1/4;
                                Console.WriteLine("Resposta incorreta. " + acertos + " respostas certas consecutivas " + "Vida restante: " + life);
                            }
                            questao++;
                            break;
                        case 4:
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("| "+ questao + " O que faz um laço de repetição (como o while)? |");
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("A. Sorteia um número aleatório toda vez que é chamado.");
                            Console.WriteLine("B. Converte um texto em número de forma contínua.");
                            Console.WriteLine("C. Pausa a execução do sistema por alguns segundos.");
                            Console.WriteLine("D. Repete um bloco de código continuamente enquanto uma condição for verdadeira.");
                            answer = Console.ReadLine();

                            if (answer == "D" || answer == "d")
                            {
                                acertos++;
                                Console.WriteLine("Resposta correta. " + acertos + " respostas certas consecutivas " + "Vida restante: " + life);
                            } else {
                                acertos = 0;
                                life = life - 100 * 1/4;
                                Console.WriteLine("Resposta incorreta. " + acertos + " respostas certas consecutivas " + "Vida restante: " + life);
                            }
                            questao++;
                            break;
                        case 5:
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("| "+ questao + " O que significa o operador lógico || (OU)? |");
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("A. Exige que todas as condições sejam verdadeiras para prosseguir.");
                            Console.WriteLine("B. Inverte o valor de uma variável (de verdadeiro para falso).");
                            Console.WriteLine("C. Resulta em verdadeiro se pelo menos uma das condições testadas for verdadeira.");
                            Console.WriteLine("D. Multiplica dois valores matemáticos.");
                            answer = Console.ReadLine();
                            
                            if (answer == "A" || answer == "a")
                            {
                                acertos++;
                                Console.WriteLine("Resposta correta. " + acertos + " respostas certas consecutivas " + "Vida restante: " + life);
                            } else {
                                acertos = 0;
                                life = life - 100 * 1/4;
                                Console.WriteLine("Resposta incorreta. " + acertos + " respostas certas consecutivas " + "Vida restante: " + life);
                            }
                            questao++;
                            break;
                    }
                }
                if(life <= 0)
                {
                    Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("|   Você zerou a sua energia, portanto ficou com sono e resolveu dormir e esperar até o próximo dia... (-_-) zzz   |");
                    Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
                } if(acertos == 3 && life > 0){
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                    Console.WriteLine("|        Você conseguiu as 3 chaves que precisava, você vai conseguir sair agora!       |");
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                }
            }
        }

        if(init == "2"){
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("|   Você decidiu não jogar o nosso jogo.  ╮(╯_╰)╭   |");
            Console.WriteLine("-----------------------------------------------------");
        }
    }
}
