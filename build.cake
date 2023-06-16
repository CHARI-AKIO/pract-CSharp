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
  public string name;
  public int price;
  public int sSizeStock;
  public int mSizeStock;
  public int lSizeStock;

  public Pizza(string name, int price, int sSizeStock, int mSizeStock, int lSizeStock){
    this.name = name;
    this.price = price;
    this.sSizeStock = sSizeStock;
    this.mSizeStock = mSizeStock;
    this.lSizeStock = lSizeStock;
  }
}

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
    line();
    Console.WriteLine("ピザ注文システム");
    Console.WriteLine("何をするか番号を入力してください");
    Console.WriteLine("1. 注文受付\n2. 在庫確認\n3. 在庫追加\n4. 終了");
    
    Console.Write("番号を入力：");
    int cmd = int.Parse(Console.ReadLine());

    switch(cmd){
      case 1:
        line();
        order(pizzaArray);
        break;
      case 2:
        line();
        checkStock(pizzaArray);
        break;
      case 3:
        line();
        addStock(pizzaArray);
        break;
      case 4:
        line();
        Console.WriteLine("ピザ注文システムを終了します。");
        end = true;
        break;
      default:
        line();
        inputError();
        break;
    }
  }
});

//注文用メソッド
Pizza[] order(Pizza[] pizzaArray){
  int price,totalPrice,cmd;
  price = 0;
  totalPrice = 0;

  string name = selectNameOrder( pizzaArray);   
  string size = selectSize();
  int count = selectCount();
  // 在庫チェック
  foreach(Pizza pizza in pizzaArray){
    bool over=false;
    if(name == pizza.name){
      switch(size){
        case "S":
          pizza.sSizeStock=stockOver(pizza.sSizeStock,count, out over);
          if(over){
            return pizzaArray;
          }
          break;
        case "M":
          pizza.lSizeStock=stockOver(pizza.lSizeStock,count, out over);
          if(over){
            return pizzaArray;
          }
          break;
        case "L":
          pizza.lSizeStock=stockOver(pizza.lSizeStock,count, out over);
          if(over){
            return pizzaArray;
          }
          break;
      }
    }
  }
    
  //料金の計算
  foreach(Pizza pizza in pizzaArray){
    if(name == pizza.name){
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
      inputError();
    }
  }
  ORDER_END:

  Console.WriteLine($"合計金額:{totalPrice}円");

  return pizzaArray;
}

//在庫確認用メソッド
void checkStock(Pizza[] pizzaArray){
  foreach(Pizza pizza in pizzaArray){
    Console.WriteLine($"{pizza.name} S:{pizza.sSizeStock.ToString()}枚");
    Console.WriteLine($"{pizza.name} M:{pizza.mSizeStock.ToString()}枚");
    Console.WriteLine($"{pizza.name} L:{pizza.lSizeStock.ToString()}枚");
  }
}

//在庫補充用メソッド
Pizza[] addStock(Pizza[] pizzaArray){
  while(true){
    string name = selectNameAdd( pizzaArray);
    if( name == "0"){
      return pizzaArray;
    }
    Console.WriteLine($"追加するピザ：{name}");

    string size = selectSize();

    int count = selectCount();

    foreach(Pizza pizza in pizzaArray){
      if( name == pizza.name ){
        switch(size){
          case "S":
            pizza.sSizeStock += count;
            break;
          case "M":
            pizza.mSizeStock += count;
            break;
          case "L":
            pizza.lSizeStock += count;
            break;
        }
      }
    }
    Console.WriteLine($"{name} {size}を{count}枚追加しました。");
    line();
  }
}

//点線用
void line(){
  Console.WriteLine("--------------------");
}

//入力用
//ピザの種類(注文)
string selectNameOrder(Pizza[] pizzaArray){
  while(true){
    dispName(pizzaArray);
    Console.Write("ピザの名前(番号でも可)を入力してください：");
    string name = Console.ReadLine();
    name = nameChange( pizzaArray, name);
    if(nameCheck( pizzaArray, name)){
      return name;
    }
  }
}

//ピザの種類(追加)
string selectNameAdd(Pizza[] pizzaArray){
  Console.WriteLine("在庫を追加するピザを選んでください");
  while(true){
    dispName(pizzaArray);
    Console.WriteLine("0.メニューに戻る");
    Console.Write("番号を入力：");
    string cmd = Console.ReadLine();
    if( cmd == "0" || cmd == "メニュー" || cmd == "メニューに戻る"){
      cmd = "0";
      return cmd;
    }
    cmd = nameChange( pizzaArray, cmd);
    if(nameCheck( pizzaArray, cmd)){
      return cmd;
    }
  }
}

//ピザの一覧表示
void dispName(Pizza[] pizzaArray){
    int x=1;
    foreach(Pizza pizza in pizzaArray){
      Console.WriteLine($"{x}.{pizza.name}");
      x++;
    }
}

//サイズを選択
string selectSize(){
  while(true){
    Console.Write("サイズを入力してください：");
    string size = Console.ReadLine();
    size = size.ToUpper();
    // ピザのサイズが存在するか？
    if(size == "S" || size == "M" || size == "L"){
      return size;
    }
    inputError();
  }
}

//枚数を入力
int selectCount(){
  Console.Write("枚数を入力してください：");
  int count = int.Parse(Console.ReadLine());
  return count;
}

//在庫チェック用
int stockOver(int stock, int order, out bool over){
  if(order <= stock){
    stock -= order;
    over = false;
  }else{
    Console.WriteLine($"在庫不足です。(在庫量：{stock}枚)");
    over = true;
  }
  return stock;
}

//nameをstrからintに変換
string nameChange( Pizza[] pizzaArray, string name){
  int nameId;
  if(int.TryParse(name, out nameId)){
    if( nameId>=1 && nameId<=5 ){
      name = pizzaArray[nameId-1].name;
    }
  }
  return name;
}
//ここまで

//nameのエラーチェック
bool nameCheck( Pizza[] pizzaArray, string name){
  //異常がなければtrueが返され、異常があればfalseが返される。
  foreach(Pizza pizza in pizzaArray){
    if( pizza.name == name ){
      return true;
    }
  }
  inputError();
  return false;
}

//エラーメッセージ用
//入力エラー
void inputError(){
  Console.WriteLine("適切な入力ではありません。");
}
//ここまで

// 指定されたターゲットの実行。必須
RunTarget(target);