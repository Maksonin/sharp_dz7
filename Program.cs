// метод для вывода запроса в консоль на ввод числа и чтение числа из консоли
int Input(string text){
    Console.WriteLine(text);
    return Convert.ToInt32(Console.ReadLine());
}

// метод для заполнения переденного массива случайными числами с возможностью вывода вещественных чисел с заданным округлением
void SetDimArray(double[,] matrix, int min_random = -10, int max_random = 10, bool doub  = false, int rou = 2){
    Random random = new Random();
    for(int i = 0; i < matrix.GetLength(0); i++){
        for(int j = 0; j < matrix.GetLength(1); j++){
            if(!doub)
                matrix[i,j] = random.Next(min_random,max_random);
            else if(doub)
                matrix[i,j] = Math.Round(random.Next(min_random,max_random) + random.NextDouble(),rou);
        }   
    }
}

// метод для вывода значений элементов массива в консоль
void PrintDimArray(double[,] matrix){
    for(int i = 0; i < matrix.GetLength(0); i++){
        for(int j = 0; j < matrix.GetLength(1); j++){
            Console.Write(matrix[i,j] + "\t");
        }
        Console.WriteLine();    
    }
}

void Task47() {
    // Задайте двумерный массив размером m×n, заполненный случайными вещественными числами, округлёнными до одного знака.
    int col = Input("Введите количество колонок");
    int row = Input("Введите количество строк");

    double[,] matrix = new double[row,col];

    SetDimArray(matrix, 0, 10, true, 1);
    PrintDimArray(matrix);
}

void Task50() {
    // Напишите программу, которая на вход принимает индексы элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.
    Random random = new Random();
    int row = random.Next(1,10);
    int col = random.Next(1,10);

    double[,] matrix = new double[row,col];

    Console.WriteLine(matrix.GetLength(0)-1);
    Console.WriteLine(matrix.GetLength(1)-1);

    SetDimArray(matrix,0,10,true);

    int find_col = Input("Введите номер колонки");
    if(find_col > matrix.GetLength(0)-1){
        Console.WriteLine($"В массиве нет колонки с номером {find_col}");
        return;
    }   
    int find_row = Input("Введите номер строки");
    if(find_row > matrix.GetLength(1)-1){
        Console.WriteLine($"В массиве нет строки с номером {find_row}");
        return;
    }

    PrintDimArray(matrix);
    Console.WriteLine($"Значение элемента массива с индексами [{find_col},{find_row}] = {matrix[find_col,find_row]}");
}

void Task52() {
    //  Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
    int row = 3;
    int col = 3;

    double[,] matrix = new double[row,col];

    SetDimArray(matrix,0,10);
    PrintDimArray(matrix);
    Console.WriteLine();
    
    for(int i = 0; i < matrix.GetLength(1); i++){
        double sum = 0;
        for(int j = 0; j < matrix.GetLength(0); j++){
            sum += matrix[j,i];
        }
        // Console.WriteLine($"{sum} / {matrix.GetLength(1)} = {sum / matrix.GetLength(1)}");
        sum /= matrix.GetLength(1);
        Console.WriteLine($"Среднее арифметическое значений {i} столбца = {Math.Round(sum,2)}");
    }
}

// метод для вывода меню выбора задач
void Menu() {
    Console.WriteLine("1 - Задача 47");
    Console.WriteLine("2 - Задача 50");
    Console.WriteLine("3 - Задача 52");

    switch (Input("Введите номер задачи - ")){
        case 1:
            Task47();
            break;
        case 2:
            Task50();
            break;
        case 3:
            Task52();
            break;
        default:
            Console.WriteLine("Задачи с таким номером не существует");
            break;
    }
}

Menu();