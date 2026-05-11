public class Program
{
    static void Main()
    {   

        // Variável que define se o jogo foi iniciado ou se o jogador saiu
        string init;

        // Inicia toda ação do programa antes da condição ser imposta ao final deste bloco
        // Após o "do", ele verifica a condição "while" e caso o jogador aperte 1 o jogo inicia e caso ele aperte 2 o jogo fecha
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

        // Se o usuário apertar 1 o jogo inicia com o jogador dentro da sala as 3 da manhã caso a condição seja verdadeira
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
            // Armazena a escolha do jogador e caso ele aperte enter, o jogo continua e caso ele apert 1 ele espera alguém abrir a porta no dia seguinte
            string choice = Console.ReadLine();

            // Variável de randomização, vida, resposta, acertos e número da questão
            Random numGenerator = new Random();
            float life = 100f;
            string answer = "";
            int acertos = 0;
            int questao = 1;
            
            // Condição que verifica se a escolha foi o número 1 e caso tenha sido, ele irá exibir a mensagem de que o jogador escolheu esperar até o dia seguinte
            if (choice == "1")
            {
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("|         Você resolveu dormir novamente e esperar até que alguém abra a portano dia seguinte... (-_-) zzz         |");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            } else {
                // Caso o jogador decida continuar, o jogo irá iniciar com as questões para conseguir as chaves
                // Condição que exibe o bloco de código abaixo caso o jogador tennhe menos que 3 acertos e a vida maior que 0
                while(acertos < 3 && life > 0)
                {
                    // Randomiza as questões a serem exibidas
                    int numQuestions = numGenerator.Next(1, 5);
                    // O switch serve para tratar o argumento imposto dentro dos parênteses, fazendo com que cada número randomizado represente uma questão por meio do case
                    switch (numQuestions)
                    {
                        case 1:
                            Console.WriteLine("-------------------------------------------------------");
                            Console.WriteLine("| "+ questao + " O que é uma variável na programação? |");
                            Console.WriteLine("-------------------------------------------------------");
                            Console.WriteLine("A. Um comando exclusivo para desligar o programa.");
                            Console.WriteLine("B. Um espaço reservado na memória do computador para guardar uma informação temporária.");
                            Console.WriteLine("C. Um erro de lógica que faz o código travar.");
                            Console.WriteLine("D. Uma ferramenta de hardware conectada ao Visual Studio.");
                            answer = Console.ReadLine();
                            
                            // Caso a resposta do joagdor seja b maiúsculo ou minúsculo, ele terá acertado a questão 
                            if (answer == "B" || answer == "b")
                            {
                                acertos++;
                                Console.WriteLine("Resposta correta. " + acertos + " respostas certas consecutivas " + "Vida restante: " + life);
                                // Caso ele erre a questão, seus pontos serão zerados e ele terá que acertar 3 questões consecutivas para avançar no game
                            } else {
                                // Acertos zerados e vida reduzida em 25%
                                acertos = 0;
                                life = life - 100 * 1/4;
                                Console.WriteLine("Resposta incorreta. " + acertos + " respostas certas consecutivas " + "Vida restante: " + life);
                            }
                            // Número da questão aumenta em 1
                            questao++;
                            break;
                        case 2:
                            Console.WriteLine("--------------------------------------------------------------------------");
                            Console.WriteLine("| "+ questao + " Qual a diferença principal entre os tipos int e string? |");
                            Console.WriteLine("--------------------------------------------------------------------------");
                            Console.WriteLine("A. int guarda textos curtos e string guarda textos longos.");
                            Console.WriteLine("B. Não há diferença, ambos guardam qualquer tipo de dado.");
                            Console.WriteLine("C. int guarda números inteiros (para cálculos) e string guarda textos.");
                            Console.WriteLine("D. int guarda números com vírgula e string guarda números inteiros.");
                            answer = Console.ReadLine();
                            
                            // Caso a resposta do joagdor seja b maiúsculo ou minúsculo, ele terá acertado a questão 
                            if (answer == "C" || answer == "c")
                            {
                                acertos++;
                                Console.WriteLine("Resposta correta. " + acertos + " respostas certas consecutivas " + "Vida restante: " + life);
                                // Caso ele erre a questão, seus pontos serão zerados e ele terá que acertar 3 questões consecutivas para avançar no game
                            } else {
                                // Acertos zerados e vida reduzida em 25%
                                acertos = 0;
                                life = life - 100 * 1/4;
                                Console.WriteLine("Resposta incorreta. " + acertos + " respostas certas consecutivas " + "Vida restante: " + life);
                            }
                            // Número da questão aumenta em 1
                            questao++;
                            break;
                        case 3:
                            Console.WriteLine("-------------------------------------------------------------");
                            Console.WriteLine("| "+ questao + " Para que serve a estrutura condicional if? |");
                            Console.WriteLine("-------------------------------------------------------------");
                            Console.WriteLine("A. Para declarar uma nova variável no sistema.");
                            Console.WriteLine("B. Para repetir um código para sempre.");
                            Console.WriteLine("C. Para tomar decisões: o código dentro dele só roda se a condição for verdadeira.");
                            Console.WriteLine("D. Para fechar o Visual Studio Code automaticamente.");
                            answer = Console.ReadLine();
                            
                            // Caso a resposta do joagdor seja b maiúsculo ou minúsculo, ele terá acertado a questão 
                            if (answer == "C" || answer == "c")
                            {
                                acertos++;
                                Console.WriteLine("Resposta correta. " + acertos + " respostas certas consecutivas " + "Vida restante: " + life);
                                // Caso ele erre a questão, seus pontos serão zerados e ele terá que acertar 3 questões consecutivas para avançar no game
                            } else {
                                // Acertos zerados e vida reduzida em 25%
                                acertos = 0;
                                life = life - 100 * 1/4;
                                Console.WriteLine("Resposta incorreta. " + acertos + " respostas certas consecutivas " + "Vida restante: " + life);
                            }
                            // Número da questão aumenta em 1
                            questao++;
                            break;
                        case 4:
                            Console.WriteLine("-----------------------------------------------------------------");
                            Console.WriteLine("| "+ questao + " O que faz um laço de repetição (como o while)? |");
                            Console.WriteLine("-----------------------------------------------------------------");
                            Console.WriteLine("A. Sorteia um número aleatório toda vez que é chamado.");
                            Console.WriteLine("B. Converte um texto em número de forma contínua.");
                            Console.WriteLine("C. Pausa a execução do sistema por alguns segundos.");
                            Console.WriteLine("D. Repete um bloco de código continuamente enquanto uma condição for verdadeira.");
                            answer = Console.ReadLine();

                            // Caso a resposta do joagdor seja b maiúsculo ou minúsculo, ele terá acertado a questão 
                            if (answer == "D" || answer == "d")
                            {
                                acertos++;
                                Console.WriteLine("Resposta correta. " + acertos + " respostas certas consecutivas " + "Vida restante: " + life);
                                // Caso ele erre a questão, seus pontos serão zerados e ele terá que acertar 3 questões consecutivas para avançar no game
                            } else {
                                // Acertos zerados e vida reduzida em 25%
                                acertos = 0;
                                life = life - 100 * 1/4;
                                Console.WriteLine("Resposta incorreta. " + acertos + " respostas certas consecutivas " + "Vida restante: " + life);
                            }
                            // Número da questão aumenta em 1
                            questao++;
                            break;
                        case 5:
                            Console.WriteLine("-------------------------------------------------------------");
                            Console.WriteLine("| "+ questao + " O que significa o operador lógico || (OU)? |");
                            Console.WriteLine("-------------------------------------------------------------");
                            Console.WriteLine("A. Exige que todas as condições sejam verdadeiras para prosseguir.");
                            Console.WriteLine("B. Inverte o valor de uma variável (de verdadeiro para falso).");
                            Console.WriteLine("C. Resulta em verdadeiro se pelo menos uma das condições testadas for verdadeira.");
                            Console.WriteLine("D. Multiplica dois valores matemáticos.");
                            answer = Console.ReadLine();

                            // Caso a resposta do joagdor seja b maiúsculo ou minúsculo, ele terá acertado a questão  
                            if (answer == "A" || answer == "a")
                            {
                                acertos++;
                                Console.WriteLine("Resposta correta. " + acertos + " respostas certas consecutivas " + "Vida restante: " + life);
                                // Caso ele erre a questão, seus pontos serão zerados e ele terá que acertar 3 questões consecutivas para avançar no game
                            } else {
                                // Acertos zerados e vida reduzida em 25%
                                acertos = 0;
                                life = life - 100 * 1/4;
                                Console.WriteLine("Resposta incorreta. " + acertos + " respostas certas consecutivas " + "Vida restante: " + life);
                            }
                            // Número da questão aumenta em 1
                            questao++;
                            break;
                    }
                }
                // Se a vida chegar a 0 ou menor que isso o jogo entrará em um estado de derrota e dirá ao usuário que ele terá que esperar até o próximo dia pelo fato de estar cansado
                if(life <= 0)
                {
                    Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("|   Você zerou a sua energia, portanto ficou com sono e resolveu dormir e esperar até o próximo dia... (-_-) zzz   |");
                    Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
                    // Caso ele acerte as 3 questões de forma consecutiva ele conseguirá as três chaves poderá sair da sala
                } if(acertos == 3 && life > 0){
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                    Console.WriteLine("|        Você conseguiu as 3 chaves que precisava, você vai conseguir sair agora!       |");
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                }
            }
        }
        // Caso o jogador clique no 2 na tela inicial ele fechará o jogo instantaneamente, decidindo não jogar o jogo
        if(init == "2"){
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("|   Você decidiu não jogar o nosso jogo.  ╮(╯_╰)╭   |");
            Console.WriteLine("-----------------------------------------------------");
        }
    }
}
