using System;

//initialize variable -- the program will stop when exitApp = true
bool exitApp = false;
//initialize variable -- var used in loops to verify good or bad input
bool goodAnswer = false;
//initialize variables == vars used to store users input from the console
string answer1 = "";
string answer2 = "";
//initialize variable -- var holds the number of numbers to print per line from user
int numPerLine = 0;
//initialize variables -- vars hold the range of numbers
int num1 = 0;
int num2 = 0;
//initialize variables -- vars are counters for each answer type
int sweet = 0;
int salty = 0;
int sweetNsalty = 0;
Console.Clear();
//welcome the user to the program
Console.WriteLine("Welcome To The Sweet and Salty Console Application");
Console.WriteLine("");                    //inform the user how it works
Console.WriteLine("                         Application Instructions");
Console.WriteLine("--------------------------------------------------------------------------------");
Console.WriteLine("This application takes three numbers as input.");
Console.WriteLine("Given a range, the application will print out Sweet for any number in the range");
Console.WriteLine("that is a multiple of 3. The application will print out Salty for any number");
Console.WriteLine("in the range that is a multiple of 5. The application will print out Sweet'nSalty");
Console.WriteLine("for any number in the range that is a multiple of both 3 and 5. The user gets to");
Console.WriteLine("decide how many numbers are printed per line up to a maximum of 30. The range of");
Console.WriteLine("the two numbers is limited to 1000.");
Console.WriteLine("");

//loop through the program until the user correctly enters information
while(!exitApp)
{
    while(!goodAnswer)
    {
        try{//try in case of bad data entry
            Console.WriteLine("Please enter the low number of the range.");
            answer1 = Console.ReadLine();
            int answerInt1 = int.Parse(answer1);
            Console.WriteLine("Please enter the high number of the range.");
            answer2 = Console.ReadLine();
            int answerInt2 = int.Parse(answer2);

            if(answerInt1 > answerInt2)//check if numbers are in wrong order
            {
                Console.WriteLine("You entered the numbers in the wrong order.");
                Console.WriteLine("");
            }else if(answerInt1 == answerInt2){//check if numbers are the same
                Console.WriteLine("The numbers cannot be equal.");
                Console.WriteLine("");
            }else if((answerInt2 - answerInt1) > 1000){//check if difference between numbers is too large
                Console.WriteLine("The difference between the numbers cannot exceed 1000.");
                Console.WriteLine("");
            }else{//entry is valid
                num1 = answerInt1;//if everything is good, fill project level variables
                num2 = answerInt2;
                goodAnswer = true;//set boolean to exit loop
                Console.Clear();
            }
        }catch(Exception){
            Console.WriteLine("Invalid Entry");//user entered invalid data
        }
    }
    goodAnswer = false;
    while(!goodAnswer)
    {
        try{//try in case of bad data entry
            goodAnswer = false;
            Console.WriteLine("How many numbers would you like to print per line?");
            answer1 = Console.ReadLine();
            numPerLine = int.Parse(answer1);
            if(numPerLine > 30 || numPerLine < 5)//check if input is out of range
            {
                Console.WriteLine("The number must be between 5 and 30");
                Console.WriteLine("");
            }else{//entry is valid
                goodAnswer = true;//set boolean to exit loop
                Console.Clear();
            }
        }catch(Exception){
            Console.WriteLine("Invalid Entry");
        }
    }
    goodAnswer = false;//set boolean back to false for next loop
    
    while(num1 != num2)//num1 is incremented, so loop until it equals num2
    {
        for(int x = 1; x <= numPerLine; x++)//loop and print numbers until user defined numbers to print per line is reached
        {
            if(num1 == 0)//if num1 = 0, don't perform modulo operation on it, just print it
            {
                Console.Write(Convert.ToString(num1 + " "));
            }else if(num1 % 3 == 0 && num1 % 5 == 0){//check if number is divisible by 3 and 5
                Console.Write("Sweet'nSalty ");
                sweetNsalty += 1;//counter for number of sweetNsalty
            }else if(num1 % 3 == 0){//check if number is divisible by 3
                Console.Write("Sweet ");
                sweet += 1;//counter for sweet
            }else if(num1 % 5 == 0){//check if number is divisible by 5
                Console.Write("Salty ");
                salty += 1;//counter for salty
            }else{
                Console.Write(Convert.ToString(num1) + " ");//number not divisible by 3 or 5
            }
            if(num1 == num2){//if num 1 = num2 in the for loop, then exit
                break;
            }
            num1 += 1; //add one to the minumum number of the range for each loop
        }
       Console.WriteLine("");
    }
    //write all counters to the console
    Console.WriteLine("Sweet: " + Convert.ToString(sweet));
    Console.WriteLine("Salty: " + Convert.ToString(salty));
    Console.WriteLine("Sweet'nSalty: " + Convert.ToString(sweetNsalty));
    exitApp = true;
}
