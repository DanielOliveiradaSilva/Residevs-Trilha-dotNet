//Aula 02
// #region 
// for (int i = 0; i <= 30; i++)
// {
//     if (i%3 == 0||i%4==0){
//         Console.WriteLine($"{i}");
//     }
    
// }
// #endregion


// #region 

// string dataString = "25/10/2023";
// // Definindo o formato da data
// string formato = "dd/MM/yyyy";
// // Convertendo a string para um objeto DateTime usando o formato especificado

// DateTime data;
// if (DateTime.TryParseExact(dataString, formato, null, System.Globalization.DateTimeStyles.None, out data)){
//      // Extraindo o dia, mês e ano do objeto DateTime
//     int dia = data.Day;
//     int mes = data.Month;
//     int ano = data.Year;

//     // Exibindo cada parte separadamente
//     Console.WriteLine("Dia: " + dia);
//             Console.WriteLine("Mês: " + mes);
//             Console.WriteLine("Ano: " + ano);
// }else{
//     Console.WriteLine("Formato de data inválido.");
//     }

// #endregion


// #region 
// // Inicializando o array de inteiros de 1 a 10
// int[] numeros = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// Console.WriteLine("Números pares:");

// // Iterando pelo array e exibindo apenas os números pares
// foreach (int numero in numeros){
//     if (numero % 2 == 0){
//             Console.WriteLine(numero);
//     }
// }
// #endregion

// #region 

// List<string> cidades = new List<string>{
//             "São Paulo",
//             "Salvador",
//             "Santiago",
//             "Sydney",
//             "Seul",
//             "Londres",
//             "Rio de Janeiro",
//             "Paris"
// };

// cidades.AddRange(new List<string> { "Seattle", "San Francisco", "São Francisco", "Shanghai" });

// Console.WriteLine("Cidades que começam com a letra 'S':");

// foreach (string cidade in cidades){
//     // Verifica se a cidade começa com "S" (ignorando se a letra começa com mausculo ou minusco)
//     if (cidade.StartsWith("S", StringComparison.OrdinalIgnoreCase)){
//         Console.WriteLine(cidade);
//     }
// }
// #endregion

#region 

Console.WriteLine("Digite uma data e hora no formato dd/MM/yyyy HH:mm:");
Console.Write("Exemplo (01/01/2024 12:00): ");

// Obtém a data e hora fornecidas pelo usuário
string entradaUsuario = Console.ReadLine();

// Converte a entrada do usuário para o tipo DateTime
if (DateTime.TryParseExact(entradaUsuario, "dd/MM/yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime dataFutura)){
    // Data e hora atual
    DateTime dataAtual = DateTime.Now;

    // Calcula a diferença de tempo em minutos
    TimeSpan diferenca = dataFutura - dataAtual;
    int diferencaEmMinutos = (int)diferenca.TotalMinutes;
        // Exibe o resultado
        Console.WriteLine($"Diferença de tempo em minutos até {dataFutura}: {diferencaEmMinutos} minutos.");
    }else{
        Console.WriteLine("Formato de data e hora inválido. Certifique-se de usar o formato correto (dd/MM/yyyy HH:mm).");
    }
    
#endregion