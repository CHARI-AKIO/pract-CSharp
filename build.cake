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
  Information("variable");
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
  Information("while");
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

// 指定されたターゲットの実行。必須
RunTarget(target);