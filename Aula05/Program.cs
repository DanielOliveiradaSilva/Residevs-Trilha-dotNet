//Expressões de Tuple
// #region 
//     var tuple = (nome: "Daniel Oliveira da Silva", idade: 22, nascimento: new DateTime(2001, 03, 22));

//     List<(string nome, int idade, DateTime nascimento)> pessoas = new List<(string nome, int idade, DateTime nascimento)>();

//     pessoas.Add(tuple);
//     pessoas.Add(("Lorena Andrade", 32, new DateTime(2005, 10, 16)));

//     foreach (var pessoa in pessoas){
//         Console.WriteLine($"Pessoa: {pessoa.nome}, {pessoa.idade}, {pessoa.nascimento.ToShortDateString()}");
//     }
// #endregion  

//Expressões lambidas
// #region 

//     string[] people = {"Daniel Oliveira da Silva", "Calos Drumom", "Jeovan Nascimento Santos", "Lorena Andrade Santos"};
//     string sobrenome = "Santos";

//     // Imprime a l is ta de pessoas com o sobrenome desejado                              Expressão Lambida
//     Console.WriteLine($"Pessoas com o sobrenome '{sobrenome}': {string.Join(", ", people.Where(p => p.Contains(sobrenome)).ToList())}");

// #endregion

// #region Linq Examples

//     List<int> list = new() { 1, 2, 3, 4, 5 };
//     var squaredList = list.Select(x => x * x);
//     Console.WriteLine($"Original List: {string.Join(", ", list)}");
//     Console.WriteLine($"Squared  List: {string.Join(", ", squaredList)}");
//     // Original List: 1, 2, 3, 4, 5
//     // Squared  List: 1, 4, 9, 16, 25
//     var summedList = list.Select((x,index) => x + squaredList.ElementAt(index));
//     Console.WriteLine($"Summed   List: {string.Join(", ", summedList)}");
//     // Summed   List: 2, 6, 12, 20, 30

//     var listMultipleOfThree = list.Where(x => x % 3 == 0).ToList();
//     listMultipleOfThree.AddRange(squaredList.Where(x => x % 3 == 0).ToList());
//     listMultipleOfThree.AddRange(summedList.Where(x => x % 3 == 0).ToList());
//     Console.WriteLine($"List Multiple of Three: {string.Join(", ", listMultipleOfThree)}");
//     // List Multiple of Three: 3, 9, 6, 12, 30
//     Console.WriteLine($"List Multiple of Three: {string.Join(", ", listMultipleOfThree.Order())}");

//     var students = new List<Student>{
//     new Student(1, "Daniel Oliveira da Silva", "123456789", new DateTime(2001, 3, 22), new List<string>{"123456789", "73988342986"}),
//     };

//     var any = students.Any();
//     var anyHelder = students.Any(x => x.FullName.Contains("Helder"));
//     //var single = students.Single(x => x.Id == 10);
//     //throw exception
//     var singleOrDefault = students.SingleOrDefault(x => x.Id == 10);

//     var select = students.Select(x => x.PhoneNumbers);
//     var selectMany = students.SelectMany(x => x.PhoneNumbers);

//     var legalAge = students.Where(x => x.BirthDate <= DateTime.Today.AddYears(-18)).Select(x => x.FullName);
//     Console.WriteLine($"Legal age people: {string.Join(", ", legalAge)}");

//     Console.Read();

// #endregion */


//#region Exceptions Examples

// try{
//    // Code that may throw an exception
//    int result = Divide(10, 11);
//    Console.WriteLine($"Result: {result}");
// }
// catch (DivideByZeroException ex){
//    // Handle the specific exception
//    Console.WriteLine("Error: Cannot divide by zero");
//    Console.WriteLine(ex.Message);
// }
// catch (Exception ex){
//    // Handle any other exceptions
//    Console.WriteLine("An error occurred");
//    Console.WriteLine(ex.Message);
// }
// finally{
//    // Code that will always execute, regardless of whether an exception occurred or not
//    Console.WriteLine("Finally block executed");
// }

// int Divide(int a, int b){
//    if (b == 0)
//    {
//       // Throw a custom exception
//       throw new DivideByZeroException("Cannot divide by zero");
//    }
//    return a / b;
// }

// #endregion 
// #region 
// int x = Console.Read();
// Console.WriteLine($"{x}");
// #endregion 