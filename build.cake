// パラメーター設定
// 第一引数が名前、第二引数がデフォルト値
string target = Argument("Target", "Default");

// 動作確認用のタスク
Task("Default")
.Does(() =>
{
  Information("Hello World");
});

// 変数とデータ型
Task("variable")
.Does(() =>
{
  string name = "yamamoto";
  int age = 18;
  bool isAdult = true;
  string[] color = {"#000000","#FFFFFF","#7D7D7D"};

  Console.WriteLine("name -> "+name);
  Console.WriteLine("age -> "+age.ToString());
  Console.WriteLine("isAdult -> "+isAdult.ToString());
  Console.WriteLine("color -> "+color[0]+","+color[1]+","+color[2]);
});

// 演算子
Task("operator")
.Does(() =>
{
  Information("operator");
});

// if文
Task("if")
.Does(() =>
{
  Information("if");
});

// switch文
Task("switch")
.Does(() =>
{
  Information("switch");
});

// for文
Task("for")
.Does(() =>
{
  Information("for");
});

// while文
Task("while")
.Does(() =>
{
  while(true){
    Console.Write("Enter：");
    string input = Console.ReadLine();
    if(input == "exit"){
      break;
    }
    Console.WriteLine(input);
  }
});


// 関数の実行確認用
Task("useSampleFunction")
.Does(() =>
{
  Information("useSampleFunction");
  SampleFunction();
  Console.WriteLine("SampleInt -> " + SampleIntFunction().ToString());
});

Task("function")
.Does(() =>
{
  Information("function");
});

void SampleFunction()
{
  Console.WriteLine("This is SampleFunction");
}

int SampleIntFunction()
{
  return 1;
}

// 課題用
Task("example1").Does(() => {
  for(int i=1;i<101;i++){
    if(i%3==0 && i%5==0){
      Console.WriteLine("FiizBuzz");
    }else if(i%3==0){
      Console.WriteLine("Fizz");
    }else if(i%5==0){
      Console.WriteLine("Buzz");
    }else{
      Console.WriteLine(i);
    }
  }
});

// 指定されたターゲットの実行。必須
RunTarget(target);