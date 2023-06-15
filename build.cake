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

// 課題用

public class Pizza{
  public string type;
  public int price;
  public int sSizeStock;
  public int mSizeStock;
  public int lSizeStock;

  public Pizza(string type, int price, int sSizeStock, int mSizeStock, int lSizeStock){
    this.type = type;
    this.price = price;
    this.sSizeStock = sSizeStock;
    this.mSizeStock = mSizeStock;
    this.lSizeStock = lSizeStock;
  }
}

  public void addStock(int add){
    /*switch(size){
      case "S":
        this.sSizeStock += add;
        Console.WriteLine($"{this.type}のSサイズを{add.ToString()}枚追加しました。");
        break;
      case "M":
        this.mSizeStock += add;
        Console.WriteLine($"{this.type}のMサイズを{add.ToString()}枚追加しました。");
        break;
      case "L":
        this.lSizeStock += add;
        Console.WriteLine($"{this.type}のLサイズを{add.ToString()}枚追加しました。");
        break;

    }*/
    
  }

  /* void checkStock(Pizza[] pizzaArray){
    foreach (Pizza pizaa in pizzaArray){
      Console.WriteLine($"{this.type} S:{this.sSizeStock.ToString()}枚");
      Console.WriteLine($"{this.type} M:{this.mSizeStock.ToString()}枚");
      Console.WriteLine($"{this.type} L:{this.lSizeStock.ToString()}枚");
    }
  } */

  

Task("pizza")
.Does(() => {
  Pizza[] pizzaArray = new Pizza[5]; 
  pizzaArray[0] = new Pizza("マルゲリータ", 480, 10, 30, 20);
  pizzaArray[1] = new Pizza("ハワイアン", 520, 30, 20, 10);
  pizzaArray[2] = new Pizza("じゃがマヨ", 570, 50, 60, 30);
  pizzaArray[3] = new Pizza("ペペロンチーノ", 600, 20, 90, 40);
  pizzaArray[4] = new Pizza("ベーコンチーズ", 440, 70, 50, 30);
  bool end=false;

  while(!(end)){
    Console.WriteLine("--------------------");
    Console.WriteLine("ピザ注文システム");
    Console.WriteLine("何をするか番号を入力してください");
    Console.WriteLine("1. 注文受付\n2. 在庫確認\n3. 在庫追加\n4. 終了");
    
    Console.WriteLine("番号を入力");
    int cmd = int.Parse(Console.ReadLine());

    switch(cmd){
      case 1:
        Console.WriteLine("--------------------");
        Order(pizzaArray);
        break;
      case 2:
        Console.WriteLine("--------------------");
        CheckStock(pizzaArray);
        break;
      case 3:
        Console.WriteLine("--------------------");
        AddStock(pizzaArray);
        break;
      case 4:
        Console.WriteLine("--------------------");
        Console.WriteLine("ピザ注文システムを終了します。");
        end = true;
        break;
      default:
        Console.WriteLine("--------------------");
        Console.WriteLine("適切な値が入力されていません。");
        break;
    }
  }
});

//注文用メソッド
Pizza[] Order(Pizza[] pizzaArray){
  string type,size;
  int count,price,totalPrice,cmd;
  price = 0;
  totalPrice = 0;

  //var orderList = new List<string>();

  while(true){
    while(true){
        foreach(Pizza pizza in pizzaArray){
          Console.WriteLine(pizza.type);
        }
        Console.Write("ピザの名前を入力してください：");
        type = Console.ReadLine();
        // ピザの種類が存在するか？
        foreach(Pizza pizza in pizzaArray){
          if(type == pizza.type){
            goto TYPE_CLEAR;
          }
        }
      Console.WriteLine("その種類のピザは存在しません。");
    }
    TYPE_CLEAR:
      
    while(true){
      Console.Write("サイズを入力してください：");
      size = Console.ReadLine();
      // ピザのサイズが存在するか？
      if(size == "S" || size == "M" || size == "L"){
        break;
      }
      Console.WriteLine("そのサイズのピザは存在しません。");
    }

    Console.Write("枚数を入力してください：");
    count = int.Parse(Console.ReadLine());
    // 在庫チェック
    switch(size){
      case "S":
        foreach(Pizza pizza in pizzaArray){
          if(type == pizza.type){
            if(count <= pizza.sSizeStock){
              pizza.sSizeStock = pizza.sSizeStock - count;   
            }else{
              Console.WriteLine("在庫不足です。");
              return pizzaArray;
            }
          }
        }
        break;
      case "M":
        foreach(Pizza pizza in pizzaArray){
          if(type == pizza.type){
            if(count <= pizza.mSizeStock){
              pizza.mSizeStock = pizza.mSizeStock - count;               
            }else{
              Console.WriteLine("在庫不足です。");
              return pizzaArray;
            }
          }
        }
        break;
      case "L":
        foreach(Pizza pizza in pizzaArray){
          if(type == pizza.type){
            if(count <= pizza.lSizeStock){
              pizza.lSizeStock = pizza.lSizeStock - count;               
            }else{
              Console.WriteLine("在庫不足です。");
              return pizzaArray;
            }
          }
        }
        break;
    }
    
    //料金の計算
    foreach(Pizza pizza in pizzaArray){
      if(type == pizza.type){
        price = pizza.price*count;
      }
    }
    switch(size){
      case "S":
        price = price * 8 / 10;
        break;
      case "M":
        price = price * 10 / 10;
        break;
      case "L":
        price = price * 12 / 10;
        break;
    }
      
    totalPrice = totalPrice + price;
    while(true){
      Console.WriteLine("注文を追加する場合は1,終了する場合は0");
      Console.Write("番号を入力：");
      cmd = int.Parse(Console.ReadLine());
      if(cmd == 0){
        goto ORDER_END;
      }else if(cmd == 1){
        break;
      }else{
        Console.WriteLine("適切な値が入力されていません。");
      }
    }
  }
  ORDER_END:

  Console.WriteLine($"合計金額:{totalPrice}円");

  Console.WriteLine("処理の完了");

  return pizzaArray;

  

  //Console.WriteLine("システムはこれ以上、実装されていません。");
}

//在庫確認用メソッド
void CheckStock(Pizza[] pizzaArray){
  foreach(Pizza pizza in pizzaArray){
    Console.WriteLine($"{pizza.type} S:{pizza.sSizeStock.ToString()}枚");
    Console.WriteLine($"{pizza.type} M:{pizza.mSizeStock.ToString()}枚");
    Console.WriteLine($"{pizza.type} L:{pizza.lSizeStock.ToString()}枚");
  }
}

//在庫補充用メソッド
Pizza[] AddStock(Pizza[] pizzaArray){
  string type,size;
  while(true){
    Console.WriteLine("在庫を追加するピザを選んでください");
    int x=1;
    foreach(Pizza pizza in pizzaArray){
      Console.WriteLine($"{x}.{pizza.type}");
      x++;
    }
    Console.WriteLine("0.メニューに戻る");
    Console.Write("番号を入力：");
    int cmd = int.Parse(Console.ReadLine());
    switch(cmd){
      case 1:
        break;
      case 2:
        break;
      case 3:
        break;
      case 4:
        break;
      case 5:
        break;
      case 0:
        return pizzaArray;
      default:
        Console.WriteLine("値が適切ではありません。");
        Console.WriteLine("--------------------");
        continue;
    }

    type = pizzaArray[cmd-1].type;
    Console.WriteLine($"追加するピザ：{pizzaArray[cmd-1].type}");
    while(true){
      Console.Write("サイズを入力してください：");
      size = Console.ReadLine();
      if( size == "S" || size == "M" || size == "L" ){
        break;
      }else{
        Console.WriteLine("適切な値が入力されませんでした。");
      }
    }
    Console.Write("枚数を入力してください：");
    
    int count = int.Parse(Console.ReadLine());

    switch(size){
      case "S":
        pizzaArray[cmd-1].sSizeStock += count;
        break;
      case "M":
        pizzaArray[cmd-1].mSizeStock += count;
        break;
      case "L":
        pizzaArray[cmd-1].lSizeStock += count;
        break;
    }
    Console.WriteLine($"{pizzaArray[cmd-1].type} {size}を{count}枚追加しました。");
    Console.WriteLine("--------------------");
  }
  //Console.WriteLine("システムが実装されていません。");
}

// 指定されたターゲットの実行。必須
RunTarget(target);