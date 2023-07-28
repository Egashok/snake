
// namespace snakeGame
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//         var field=new Field();
//         field.fillField();
//         var game=new Game();
//         var snake=new snakeModel();
//          while (true) {
//             if (Console.KeyAvailable) {
//                 ConsoleKeyInfo key = Console.ReadKey ();
//                 snakeModel.Rotation(key.Key);
//             }
        
//         }
//         }
//     }
// }

// public class Field{

//     public string[,] sizeField=new string [10,10];
    
//     public void fillField(){
//         for(int i=0;i<10;i++)
//         {  
//             for(int j=0;j<10;j++){
//                 sizeField[i,j]=" ";
//             }
//         }
//         this.createWalls();
//     }

//     public void createWalls(){
//         for(int i=0;i<10;i+=9)
//         {  
//             for(int j=0;j<10;j++){
//                 sizeField[i,j]="#";
//             }
//         }
//         for(int i=0;i<10;i+=9)
//         {  
//             for(int j=0;j<10;j++){
//                 sizeField[j,i]="#";
//             }
//         }
//         this.ShowField();
//     }
//     public void ShowField(){
//          for(int i=0;i<10;i++)
//         {  
//             for(int j=0;j<10;j++){
//                 Console.Write($" {sizeField[i,j]}");
//             }
//             Console.WriteLine();
//         }
//     }
// }
// public class snakeModel{
    
//     public int lengthSnake=2;
//     const int weightSnake=1;
//     public string iconSnake="*";
// }

// public class Apple{
//     int x;
//     int y;
//     const int lengthApple=1;
//     const int weightApple=1;
//     public string iconApple="@";

//     public void AppleCreate(){
//     var random = new Random();
//         x=random.Next(0,9);
//         y=random.Next(0,9);
//     }
// }

// public class Game{
//     int score=0;
//     public void Start(Field field){
    
//     }

//     public void Update(){
    

//      }

//     public class statusGame{
//         public bool lose=false;
       
//     }
    
// }