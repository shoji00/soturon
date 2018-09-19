using Newtonsoft.Json;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace shoji_Layout
{
    class MainWindowViewModel
    {
        /// <summary>
        /// 駅のレイアウト
        /// </summary>
        private StationLayoutParam station_;

        ///<summary>
        ///ノードのリスト
        ///</summary>
        private List<Node> nodes_;

        ///<summary>
        ///画像のサイズ変更
        ///</summary>
        private Image image_;

        ///<summary>
        ///画像のビットマップの表示
        ///</summary>
        public RenderTargetBitmap Bitmap { get; set; }

        ///<summary>
        ///レンタリング用のビジュアル
        ///</summary>
        public DrawingVisual DrawVisual { get; set; }

        /// <summary>
        /// ビジュアルコンテンツ
        /// </summary>
        public DrawingContext DrawContext { get; set; }

        /// <summary>
        /// レイアウトの縦幅
        /// </summary>
        public ReactiveProperty<int> LayoutHeight { get; set; }

        /// <summary>
        /// レイアウトの横幅
        /// </summary>
        public ReactiveProperty<int> LayoutWidth { get; set; }

        /// <summary>
        /// 改札の横幅
        /// </summary>
        public ReactiveProperty<double> KaisatuWidth { get; set; }

        /// <summary>
        /// 改札の縦幅
        /// </summary>
        public ReactiveProperty<double> KaisatuHeight { get; set; }

        /// <summary>
        /// 改札のX座標
        /// </summary>
        public ReactiveProperty<double> KaisatuX { get; set; }

        /// <summary>
        /// 改札のY座標
        /// </summary>
        public ReactiveProperty<double> KaisatuY { get; set; }

        /// <summary>
        /// エレベーターの横幅
        /// </summary>
        public ReactiveProperty<double> ElevatorWidth { get; set; }

        /// <summary>
        /// エレベーターの縦幅
        /// </summary>
        public ReactiveProperty<double> ElevatorHeight { get; set; }

        /// <summary>
        /// エレベーターのX座標
        /// </summary>
        public ReactiveProperty<double> ElevatorX { get; set; }

        /// <summary>
        /// エレベーターのY座標
        /// </summary>
        public ReactiveProperty<double> ElevatorY { get; set; }

        /// <summary>
        /// 駅員室の横幅
        /// </summary>
        public ReactiveProperty<double> RoomWidth { get; set; }

        /// <summary>
        /// 駅員室の縦幅
        /// </summary>
        public ReactiveProperty<double> RoomHeight { get; set; }

        /// <summary>
        /// 駅員室のX座標
        /// </summary>
        public ReactiveProperty<double> RoomX { get; set; }

        /// <summary>
        ///  駅員室のY座標
        /// </summary>
        public ReactiveProperty<double> RoomY { get; set; }

        /// <summary>
        /// 階段の横幅
        /// </summary>
        public ReactiveProperty<double> StairsWidth { get; set; }

        /// <summary>
        /// 階段の縦幅
        /// </summary>
        public ReactiveProperty<double> StairsHeight { get; set; }

        /// <summary>
        /// 階段のX座標
        /// </summary>
        public ReactiveProperty<double> StairsX { get; set; }

        /// <summary>
        /// 階段のY座標
        /// </summary>
        public ReactiveProperty<double> StairsY { get; set; }


        /// <summary>
        /// 出口の横幅
        /// </summary>
        public ReactiveProperty<double> GoalWidth { get; set; }

        /// <summary>
        /// 出口の縦幅
        /// </summary>
        public ReactiveProperty<double> GoalHeight { get; set; }

        /// <summary>
        /// 出口のX座標
        /// </summary>
        public ReactiveProperty<double> GoalX { get; set; }

        /// <summary>
        /// 出口のY座標
        /// </summary>
        public ReactiveProperty<double> GoalY { get; set; }

        /// <summary>
        /// ベンチの横幅
        /// </summary>
        public ReactiveProperty<double> BenchWidth { get; set; }

        /// <summary>
        /// ベンチの縦幅
        /// </summary>
        public ReactiveProperty<double> BenchHeight { get; set; }

        /// <summary>
        /// ベンチのX座標
        /// </summary>
        public ReactiveProperty<double> BenchX { get; set; }

        /// <summary>
        /// ベンチのY座標
        /// </summary>
        public ReactiveProperty<double> BenchY { get; set; }

        /// <summary>
        /// 柱の横幅
        /// </summary>
        public ReactiveProperty<double> PillarWidth { get; set; }

        /// <summary>
        /// 柱の縦幅
        /// </summary>
        public ReactiveProperty<double> PillarHeight { get; set; }

        /// <summary>
        /// 柱のX座標
        /// </summary>
        public ReactiveProperty<double> PillarX { get; set; }

        /// <summary>
        /// 柱のY座標
        /// </summary>
        public ReactiveProperty<double> PillarY { get; set; }

        /// <summary>
        /// 自動販売機の横幅
        /// </summary>
        public ReactiveProperty<double> DrinkWidth { get; set; }

        /// <summary>
        /// 自動販売機の縦幅
        /// </summary>
        public ReactiveProperty<double> DrinkHeight { get; set; }

        /// <summary>
        /// 自動販売機のX座標
        /// </summary>
        public ReactiveProperty<double> DrinkX { get; set; }

        /// <summary>
        /// 自動販売機のY座標
        /// </summary>
        public ReactiveProperty<double> DrinkY { get; set; }

        /// <summary>
        /// レイアウトの大きさを更新するコマンド
        /// </summary>
        public ReactiveCommand UpdateLayoutSize { get; set; }

        /// <summary>
        /// レイアウト情報を読み込むコマンド
        /// </summary>
        public ReactiveCommand LoadLayoutCommand { get; set; }

        /// <summary>
        /// レイアウト情報を保存するコマンド
        /// </summary>
        public ReactiveCommand SaveLayoutCommand { get; set; }

        /// <summary>
        /// 改札を追加するコマンド
        /// </summary>
        public ReactiveCommand AddKaisatuCommand { get; set; }

        /// <summary>
        /// 改札を削除するコマンド
        /// </summary>
        public ReactiveCommand RemoveKaisatuCommand { get; set; }

        /// <summary>
        /// エレベーターを追加するコマンド
        /// </summary>
        public ReactiveCommand AddElevatorCommand { get; set; }

        /// <summary>
        /// エレベーターを削除するコマンド
        /// </summary>
        public ReactiveCommand RemoveElevatorCommand { get; set; }

        /// <summary>
        /// 駅員室を追加するコマンド
        /// </summary>
        public ReactiveCommand AddRoomCommand { get; set; }

        /// <summary>
        /// 駅員室を削除するコマンド
        /// </summary>
        public ReactiveCommand RemoveRoomCommand { get; set; }

        /// <summary>
        /// 階段を追加するコマンド
        /// </summary>
        public ReactiveCommand AddStairsCommand { get; set; }

        /// <summary>
        /// 階段を削除するコマンド
        /// </summary>
        public ReactiveCommand RemoveStairsCommand { get; set; }

        /// <summary>
        /// 出口を追加するコマンド
        /// </summary>
        public ReactiveCommand AddGoalCommand { get; set; }

        /// <summary>
        /// 出口を削除するコマンド
        /// </summary>
        public ReactiveCommand RemoveGoalCommand { get; set; }

        /// <summary>
        /// ベンチを追加するコマンド
        /// </summary>
        public ReactiveCommand AddBenchCommand { get; set; }

        /// <summary>
        /// ベンチを削除するコマンド
        /// </summary>
        public ReactiveCommand RemoveBenchCommand { get; set; }

        /// <summary>
        /// 柱を追加するコマンド
        /// </summary>
        public ReactiveCommand AddPillarCommand { get; set; }

        /// <summary>
        /// 柱を削除するコマンド
        /// </summary>
        public ReactiveCommand RemovePillarCommand { get; set; }

        /// <summary>
        /// 自動販売機を追加するコマンド
        /// </summary>
        public ReactiveCommand AddDrinkCommand { get; set; }

        /// <summary>
        /// 自動販売機を削除するコマンド
        /// </summary>
        public ReactiveCommand RemoveDrinkCommand { get; set; }

        /// <summary>
        /// Xamlデザイナー用のコンストラクタ
        /// </summary>
        public MainWindowViewModel()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="image">XamlにあるImageコントロール</param>
        public MainWindowViewModel(Image image)
        {
            station_ = new StationLayoutParam();

            nodes_ = new List<Node>();

            image_ = image;

            LayoutWidth = new ReactiveProperty<int>(station_.Width);

            LayoutHeight = new ReactiveProperty<int>(station_.Height);

            KaisatuWidth = new ReactiveProperty<double>(50);

            KaisatuHeight = new ReactiveProperty<double>(50);

            KaisatuX = new ReactiveProperty<double>(0);

            KaisatuY = new ReactiveProperty<double>(0);

            ElevatorWidth = new ReactiveProperty<double>(50);

            ElevatorHeight = new ReactiveProperty<double>(50);

            ElevatorX = new ReactiveProperty<double>(0);

            ElevatorY = new ReactiveProperty<double>(0);

            RoomWidth = new ReactiveProperty<double>(50);

            RoomHeight = new ReactiveProperty<double>(50);

            RoomX = new ReactiveProperty<double>(0);

            RoomY = new ReactiveProperty<double>(0);

            StairsWidth = new ReactiveProperty<double>(50);

            StairsHeight = new ReactiveProperty<double>(50);

            StairsX = new ReactiveProperty<double>(0);

            StairsY = new ReactiveProperty<double>(0);

            GoalWidth = new ReactiveProperty<double>(10);

            GoalHeight = new ReactiveProperty<double>(100);

            GoalX = new ReactiveProperty<double>(0);

            GoalY = new ReactiveProperty<double>(0);

            BenchWidth = new ReactiveProperty<double>(50);

            BenchHeight = new ReactiveProperty<double>(50);

            BenchX = new ReactiveProperty<double>(0);

            BenchY = new ReactiveProperty<double>(0);

            PillarWidth = new ReactiveProperty<double>(50);

            PillarHeight = new ReactiveProperty<double>(50);

            PillarX = new ReactiveProperty<double>(0);

            PillarY = new ReactiveProperty<double>(0);

            DrinkWidth = new ReactiveProperty<double>(50);

            DrinkHeight = new ReactiveProperty<double>(50);

            DrinkX = new ReactiveProperty<double>(0);

            DrinkY = new ReactiveProperty<double>(0);

            Bitmap = new RenderTargetBitmap(
                station_.Width,
                station_.Height,
                96,
                96,
                PixelFormats.Default);

            DrawVisual = new DrawingVisual();

            UpdateLayoutSize = new ReactiveCommand();

            UpdateLayoutSize.Subscribe(_ =>
            {
                station_.Height = LayoutHeight.Value;
                station_.Width = LayoutWidth.Value;
                DrawLayout();
            });

            LoadLayoutCommand = new ReactiveCommand();

            LoadLayoutCommand.Subscribe(_ => OpenFile());

            SaveLayoutCommand = new ReactiveCommand();

            SaveLayoutCommand.Subscribe(_ => SaveLayout());

            AddKaisatuCommand = new ReactiveCommand();

            AddKaisatuCommand.Subscribe(_ => AddKaisatus());

            RemoveKaisatuCommand = new ReactiveCommand();

            RemoveKaisatuCommand.Subscribe(_ => RemoveKaisatu());

            AddElevatorCommand = new ReactiveCommand();

            AddElevatorCommand.Subscribe(_ => AddElevators());

            RemoveElevatorCommand = new ReactiveCommand();

            RemoveElevatorCommand.Subscribe(_ => RemoveElevator());

            AddRoomCommand = new ReactiveCommand();

            AddRoomCommand.Subscribe(_ => AddRooms());

            RemoveRoomCommand = new ReactiveCommand();

            RemoveRoomCommand.Subscribe(_ => RemoveRoom());

            AddStairsCommand = new ReactiveCommand();

            AddStairsCommand.Subscribe(_ => AddStairss());

            RemoveStairsCommand = new ReactiveCommand();

            RemoveStairsCommand.Subscribe(_ => RemoveStairs());

            AddGoalCommand = new ReactiveCommand();

            AddGoalCommand.Subscribe(_ => AddGoals());

            RemoveGoalCommand = new ReactiveCommand();

            RemoveGoalCommand.Subscribe(_ => RemoveGoal());

            AddBenchCommand = new ReactiveCommand();

            AddBenchCommand.Subscribe(_ => AddBenchs());

            RemoveBenchCommand = new ReactiveCommand();

            RemoveBenchCommand.Subscribe(_ => RemoveBench());

            AddPillarCommand = new ReactiveCommand();

            AddPillarCommand.Subscribe(_ => AddPillars());

            RemovePillarCommand = new ReactiveCommand();

            RemovePillarCommand.Subscribe(_ => RemovePillar());

            AddDrinkCommand = new ReactiveCommand();

            AddDrinkCommand.Subscribe(_ => AddDrinks());

            RemoveDrinkCommand = new ReactiveCommand();

            RemoveDrinkCommand.Subscribe(_ => RemoveDrink());

            //描画（リストは空なので白い大きな四角）
            DrawLayout();
        }

        /// <summary>
        /// Jsonファイルからレイアウト情報を読み込む関数
        /// </summary>
        public void OpenFile()
        {
            using (var fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Json Files(.json)|*.json";
                fileDialog.Title = "開くファイルを選択してください";
                fileDialog.Multiselect = false;


                //ダイアログを表示する
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var streamReader = new StreamReader(fileDialog.FileName))
                    {
                        var json = streamReader.ReadToEnd();

                        station_ = JsonConvert.DeserializeObject<StationLayoutParam>(json);

                        nodes_.Clear();

                                               
                        //ノードの設定
                        foreach ( var seats in station_.Kaisatus)
                        {
                            double distance = 25;

                            SetUpNodes(new Node(
                                seats[0].PositionX - (seats[0].Width / 2) - distance,
                                seats[0].PositionY - (seats[0].Height / 2) - distance));
                            SetUpNodes(new Node(
                                seats[0].PositionX - (seats[0].Width / 2) - distance,
                                seats[0].PositionY + (seats[0].Height / 2) + distance));
                            SetUpNodes(new Node(
                                seats[seats.Count() - 1].PositionX + (seats[0].Width / 2) + distance,
                                seats[seats.Count() - 1].PositionY - (seats[0].Height / 2) - distance));
                            SetUpNodes(new Node(
                                seats[seats.Count() - 1].PositionX + (seats[0].Width / 2) + distance,
                                seats[seats.Count() - 1].PositionY + (seats[0].Height / 2) + distance));
                        }

                    }



                    }

                }
            }

            LayoutWidth.Value = station_.Width;
            LayoutHeight.Value = station_.Height;

            DrawLayout();
        }

        /// <summary>
        /// 現在のレイアウト情報をJsonファイルとして保存する関数
        /// </summary>
        public void SaveLayout()
        {
            using (var fileDialog = new SaveFileDialog())
            {
                fileDialog.Filter = "Json Files(.json)|*.json";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var streamWriter = new StreamWriter(fileDialog.FileName, false))
                    {
                        streamWriter.WriteLine(JsonConvert.SerializeObject(station_, Formatting.Indented));
                    }
                }
            }
        }

        /// <summary>
        /// レイアウト情報に改札を追加する関数
        /// </summary>
        public void AddKaisatus()
        {
            station_.Kaisatus.Add(new StationKaisatuParam(KaisatuWidth.Value, KaisatuHeight.Value, KaisatuX.Value, KaisatuY.Value));

            DrawLayout();
        }

        /// <summary>
        /// リストの最後に存在する改札情報を削除する
        /// </summary>
        public void RemoveKaisatu()
        {
            if (station_.Kaisatus.Count() != 0)
            {
                station_.Kaisatus.RemoveAt(station_.Kaisatus.Count() - 1);
            }

            DrawLayout();
        }

        /// <summary>
        /// レイアウト情報にエレベーターを追加する関数
        /// </summary>
        public void AddElevators()
        {
            station_.Elevators.Add(new StationElevatorParam(ElevatorWidth.Value, ElevatorHeight.Value, ElevatorX.Value, ElevatorY.Value));

            DrawLayout();
        }

        /// <summary>
        /// リストの最後に存在するエレベーター情報を削除する
        /// </summary>
        public void RemoveElevator()
        {
            if (station_.Elevators.Count() != 0)
            {
                station_.Elevators.RemoveAt(station_.Elevators.Count() - 1);
            }

            DrawLayout();
        }

        /// <summary>
        /// レイアウト情報に駅員室を追加する関数
        /// </summary>
        public void AddRooms()
        {
            station_.Rooms.Add(new StationRoomParam(RoomWidth.Value, RoomHeight.Value, RoomX.Value, RoomY.Value));

            DrawLayout();
        }

        /// <summary>
        /// リストの最後に存在する駅員室情報を削除する
        /// </summary>
        public void RemoveRoom()
        {
            if (station_.Rooms.Count() != 0)
            {
                station_.Rooms.RemoveAt(station_.Rooms.Count() - 1);
            }

            DrawLayout();
        }

        /// <summary>
        /// レイアウト情報に階段を追加する関数
        /// </summary>
        public void AddStairss()
        {
            station_.Stairss.Add(new StationStairsParam(StairsWidth.Value, StairsHeight.Value, StairsX.Value, StairsY.Value));

            DrawLayout();
        }

        /// <summary>
        /// リストの最後に存在する階段情報を削除する
        /// </summary>
        public void RemoveStairs()
        {
            if (station_.Stairss.Count() != 0)
            {
                station_.Stairss.RemoveAt(station_.Stairss.Count() - 1);
            }

            DrawLayout();
        }

        /// <summary>
        /// レイアウト情報に出口を追加する
        /// </summary>
        public void AddGoals()
        {
            station_.Goals.Add(new StationGoalParam(GoalWidth.Value, GoalHeight.Value, GoalX.Value, GoalY.Value));

            DrawLayout();
        }

        /// <summary>
        /// リストの最後に存在する出口を削除する
        /// </summary>
        public void RemoveGoal()
        {
            if (station_.Goals.Count() != 0)
            {
                station_.Goals.RemoveAt(station_.Goals.Count() - 1);
            }

            DrawLayout();
        }

        /// <summary>
        /// レイアウト情報にベンチを追加する関数
        /// </summary>
        public void AddBenchs()
        {
            station_.Benchs.Add(new StationBenchParam(BenchWidth.Value, BenchHeight.Value, BenchX.Value, BenchY.Value));

            DrawLayout();
        }

        /// <summary>
        /// リストの最後に存在するベンチ情報を削除する
        /// </summary>
        public void RemoveBench()
        {
            if (station_.Benchs.Count() != 0)
            {
                station_.Benchs.RemoveAt(station_.Benchs.Count() - 1);
            }

            DrawLayout();
        }

        /// <summary>
        /// レイアウト情報に柱を追加する関数
        /// </summary>
        public void AddPillars()
        {
            station_.Pillars.Add(new StationPillarParam(PillarWidth.Value, PillarHeight.Value, PillarX.Value, PillarY.Value));

            DrawLayout();
        }

        /// <summary>
        /// リストの最後に存在するベンチ情報を削除する
        /// </summary>
        public void RemovePillar()
        {
            if (station_.Pillars.Count() != 0)
            {
                station_.Pillars.RemoveAt(station_.Pillars.Count() - 1);
            }

            DrawLayout();
        }

        /// <summary>
        /// レイアウト情報にベンチを追加する関数
        /// </summary>
        public void AddDrinks()
        {
            station_.Drinks.Add(new StationDrinkParam(DrinkWidth.Value, DrinkHeight.Value, DrinkX.Value, DrinkY.Value));

            DrawLayout();
        }

        /// <summary>
        /// リストの最後に存在するベンチ情報を削除する
        /// </summary>
        public void RemoveDrink()
        {
            if (station_.Drinks.Count() != 0)
            {
                station_.Drinks.RemoveAt(station_.Drinks.Count() - 1);
            }

            DrawLayout();
        }


        /// <summary>
        /// レイアウトを描画する関数
        /// </summary>
        /// <param name="layout">レイアウトの情報</param>
        public void DrawLayout()
        {
            Bitmap = new RenderTargetBitmap(
                station_.Width,
                station_.Height,
                96,
                96,
                PixelFormats.Default);

            //これをしないと画像が更新されない
            image_.Source = Bitmap;

            DrawContext = DrawVisual.RenderOpen();

            //描画するオブジェクトの作成
            DrawContext.DrawRectangle(Brushes.White, null, new Rect(0, 0, LayoutWidth.Value, LayoutHeight.Value));

            //改札の描画
            foreach (var kaisatu in station_.Kaisatus)
            {
                    DrawContext.DrawRectangle(
                        Brushes.White,
                        new Pen(Brushes.Black, 1),
                        new Rect(kaisatu.PositionX - kaisatu.Width / 2, kaisatu.PositionY - kaisatu.Height / 2, kaisatu.Width, kaisatu.Height));
            }

            //エレベーターの描画
            foreach (var elevator in station_.Elevators)
            {
                DrawContext.DrawRectangle(
                    Brushes.White,
                    new Pen(Brushes.Black, 1),
                    new Rect(elevator.PositionX - elevator.Width / 2, elevator.PositionY - elevator.Height / 2, elevator.Width, elevator.Height));
            }

            //駅員室の描画
            foreach (var room in station_.Rooms)
            {
                DrawContext.DrawRectangle(
                    Brushes.White,
                    new Pen(Brushes.Black, 1),
                    new Rect(room.PositionX - room.Width / 2, room.PositionY - room.Height / 2, room.Width, room.Height));
            }

            //階段の描画
            foreach (var stairs in station_.Stairss)
            {
                DrawContext.DrawRectangle(
                    Brushes.White,
                    new Pen(Brushes.Black, 1),
                    new Rect(stairs.PositionX - stairs.Width / 2, stairs.PositionY - stairs.Height / 2, stairs.Width, stairs.Height));
            }

            //出口の描画
            foreach (var goal in station_.Goals)
            {
                DrawContext.DrawRectangle(
                    Brushes.Red,
                    null,
                    new Rect(goal.PositionX - goal.Width / 2, goal.PositionY - goal.Height / 2, goal.Width, goal.Height));
            }

            //ベンチの描画
            foreach (var bench in station_.Benchs)
            {
                DrawContext.DrawRectangle(
                    Brushes.Red,
                    null,
                    new Rect(bench.PositionX - bench.Width / 2, bench.PositionY - bench.Height / 2, bench.Width, bench.Height));
            }

            //柱の描画
            foreach (var pillar in station_.Pillars)
            {
                DrawContext.DrawRectangle(
                    Brushes.Red,
                    null,
                    new Rect(pillar.PositionX - pillar.Width / 2, pillar.PositionY - pillar.Height / 2, pillar.Width, pillar.Height));
            }

            //自動販売機の描画
            foreach (var drink in station_.Drinks)
            {
                DrawContext.DrawRectangle(
                    Brushes.Red,
                    null,
                    new Rect(drink.PositionX - drink.Width / 2, drink.PositionY - drink.Height / 2, drink.Width, drink.Height));
            }


            DrawContext.Close();

            //表示する画像を更新 
            Bitmap.Render(DrawVisual);
        }


    }
}
