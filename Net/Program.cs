///Questão 02
// #region 
//     int a = 10;
//     int b = 5;
//     int soma = a + b; // Operação de adição

//     long grandeNumero = 1234567890123456789L; // O sufixo 'L' indica que é um literal longo

//     byte idade = 25;
//     ushort codigo = 5000;

//     short temperatura = -15;
//     sbyte valor = -50;
// #endregion

//Qestão 03
#region 
    double numeroDouble = 10.8; // Exemplo de um número double com parte fracionária
    int numeroInteiro = (int)numeroDouble; // Conversão explícita de double para int

    Console.WriteLine("Valor double: " + numeroDouble);
    Console.WriteLine("Valor convertido para int: " + numeroInteiro);
#endregion

//Questão 04
#region
    int x = 10;
    int y = 3;
    double result;
    result = x + y;

    Console.WriteLine($"Soma:\n{x} + {y} é: " + (x+y));
    Console.WriteLine($"Divisão:\n{x} - {y} é: " + (x- y));
    Console.WriteLine($"Multiplicação:\n{x} é {y} é: " + (x*y));
    Console.WriteLine($"Divisão:\n{x}/{y} é: {((double)x/(double)y):F2}");
#endregion

//Questão 05
#region 
    int a = 5;
    int b = 8;

    if(a > b){
        Console.WriteLine($"{a}");
    }else if(b > a){
        Console.WriteLine($"{b}");
    }else{
        Console.WriteLine("Igual");
    }
#endregion

//Questão 06
#region 
    string str1 = "Hello";
    string str2 = "World";

    // Verifica se as duas strings são iguais usando o operador ==


    // Exibe o resultado da comparação
    if (str1 == str2){
        Console.WriteLine("As strings são iguais.");
    }
    else{
        Console.WriteLine("As strings são diferentes.");
    }
#endregion

//Questao 07
#region 
    bool condicao1 = true;
    bool condicao2 = false;
    if(condicao1 == true && condicao2 ==true ){
        Console.WriteLine("true");
    }else{
        Console.WriteLine("false");
    }
#endregion

//Questão 08
#region 
    int num1 = 7;
    int num2 = 3;
    int num3 = 10;

    if(num1 > num2){
        Console.WriteLine($"{num1} é maior que {num2}");
    }
    if(num3 == (num1+num2)){
        Console.WriteLine($"{num3} é igual a ({num1} + {num2}) ");
    }
#endregion
