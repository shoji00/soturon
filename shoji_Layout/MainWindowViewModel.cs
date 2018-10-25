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
    public class MainWindowViewModel
    {
        /// <summary>
        /// 駅のレイアウト
        /// </summary>
        private StationLayoutParam station_;

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
        public ReactiveProperty<double> StairsUpWidth { get; set; }
        public ReactiveProperty<double> StairsDownWidth { get; set; }

        /// <summary>
        /// 階段の縦幅
        /// </summary>
        public ReactiveProperty<double> StairsUpHeight { get; set; }
        public ReactiveProperty<double> StairsDownHeight { get; set; }

        /// <summary>
        /// 階段のX座標
        /// </summary>
        public ReactiveProperty<double> StairsUpX { get; set; }
        public ReactiveProperty<double> StairsDownX { get; set; }

        /// <summary>
        /// 階段のY座標
        /// </summary>
        public ReactiveProperty<double> StairsUpY { get; set; }
        public ReactiveProperty<double> StairsDownY { get; set; }

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
        public ReactiveCommand AddStairsUpCommand { get; set; }
        public ReactiveCommand AddStairsDownCommand { get; set; }

        /// <summary>
        /// 階段を削除するコマンド
        /// </summary>
        public ReactiveCommand RemoveStairsUpCommand { get; set; }
        public ReactiveCommand RemoveStairsDownCommand { get; set; }
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

            image_ = image;

            LayoutWidth = new ReactiveProperty<int>(station_.Width);

            LayoutHeight = new ReactiveProperty<int>(station_.Height);

            KaisatuWidth = new ReactiveProperty<double>(50);

            KaisatuHeight = new ReactiveProperty<double>(50);

            KaisatuX = new ReactiveProperty<double>(0);

            KaisatuY = new ReactiveProperty<double>(0);

            RoomWidth = new ReactiveProperty<double>(50);

            RoomHeight = new ReactiveProperty<double>(50);

            RoomX = new ReactiveProperty<double>(0);

            RoomY = new ReactiveProperty<double>(0);

            StairsUpWidth = new ReactiveProperty<double>(50);

            StairsUpHeight = new ReactiveProperty<double>(50);

            StairsUpX = new ReactiveProperty<double>(0);

            StairsUpY = new ReactiveProperty<double>(0);

            StairsDownWidth = new ReactiveProperty<double>(50);

            StairsDownHeight = new ReactiveProperty<double>(50);

            StairsDownX = new ReactiveProperty<double>(0);

            StairsDownY = new ReactiveProperty<double>(0);

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

            AddRoomCommand = new ReactiveCommand();

            AddRoomCommand.Subscribe(_ => AddRooms());

            RemoveRoomCommand = new ReactiveCommand();

            RemoveRoomCommand.Subscribe(_ => RemoveRoom());

            AddStairsUpCommand = new ReactiveCommand();

            AddStairsUpCommand.Subscribe(_ => AddStairsUp());

            RemoveStairsUpCommand = new ReactiveCommand();

            RemoveStairsUpCommand.Subscribe(_ => RemoveStairsUp());

            AddStairsDownCommand = new ReactiveCommand();

            AddStairsDownCommand.Subscribe(_ => AddStairsDown());

            RemoveStairsDownCommand = new ReactiveCommand();

            RemoveStairsDownCommand.Subscribe(_ => RemoveStairsDown());


            AddGoalCommand = new ReactiveCommand();

            AddGoalCommand.Subscribe(_ => AddGoals());

            RemoveGoalCommand = new ReactiveCommand();

            RemoveGoalCommand.Subscribe(_ => RemoveGoal());

            AddBenchCommand = new ReactiveCommand();

            AddBenchCommand.Subscribe(_ => AddBenchs());

            RemoveBenchCommand = new ReactiveCommand();

            RemoveBenchCommand.Subscribe(_ => RemoveBench());


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

            }
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
        public void AddStairsUp()
        {
            station_.StairsUp.Add(new StationStairsUpParam(StairsUpWidth.Value, StairsUpHeight.Value, StairsUpX.Value, StairsUpY.Value));

            DrawLayout();
        }

        /// <summary>
        /// リストの最後に存在する階段情報を削除する
        /// </summary>
        public void RemoveStairsUp()
        {
            if (station_.StairsUp.Count() != 0)
            {
                station_.StairsUp.RemoveAt(station_.StairsUp.Count() - 1);
            }

            DrawLayout();
        }

        /// <summary>
        /// レイアウト情報に階段を追加する関数
        /// </summary>
        public void AddStairsDown()
        {
            station_.StairsDown.Add(new StationStairsDownParam(StairsDownWidth.Value, StairsDownHeight.Value, StairsDownX.Value, StairsDownY.Value));

            DrawLayout();
        }

        /// <summary>
        /// リストの最後に存在する階段情報を削除する
        /// </summary>
        public void RemoveStairsDown()
        {
            if (station_.StairsDown.Count() != 0)
            {
                station_.StairsDown.RemoveAt(station_.StairsDown.Count() - 1);
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
                    Brushes.Yellow,
                    new Pen(Brushes.Black, 1),
                    new Rect(kaisatu.PositionX  - kaisatu.Width / 2 , kaisatu.PositionY - kaisatu.Height / 2, kaisatu.Width, kaisatu.Height));
            }


            //駅員室の描画
            foreach (var room in station_.Rooms)
            {
                DrawContext.DrawRectangle(
                    Brushes.Black,
                    new Pen(Brushes.Black, 1),
                    new Rect(room.PositionX - room.Width / 2 , room.PositionY - room.Height / 2 , room.Width, room.Height));
            }

            //上に線がある階段の描画
            foreach (var stairsUp in station_.StairsUp)
            {
                ///<summary>
                ///左の線
                /// </summary>
                DrawContext.DrawLine(
                    new Pen(Brushes.Black, 1),
                    new Point(stairsUp.PositionX - stairsUp.Width / 2, stairsUp.PositionY - stairsUp.Height / 2),
                    new Point(stairsUp.PositionX - stairsUp.Width / 2, stairsUp.PositionY - stairsUp.Height / 2 + stairsUp.Height));

                ///<summary>
                ///右の線
                /// </summary>
                DrawContext.DrawLine(
                    new Pen(Brushes.Black, 1),
                    new Point(stairsUp.PositionX + stairsUp.Width - stairsUp.Width / 2, stairsUp.PositionY - stairsUp.Height / 2),
                    new Point(stairsUp.PositionX + stairsUp.Width - stairsUp.Width / 2, stairsUp.PositionY + stairsUp.Height -stairsUp.Height / 2));

                ///<summary>
                ///上の線
                /// </summary>
                DrawContext.DrawLine(
                    new Pen(Brushes.Black, 1),
                    new Point(stairsUp.PositionX - stairsUp.Width / 2, stairsUp.PositionY - stairsUp.Height / 2),
                    new Point(stairsUp.PositionX + stairsUp.Width - stairsUp.Width / 2, stairsUp.PositionY -stairsUp.Height / 2));
            }


            //下に線がある階段の描画
            foreach (var stairsDown in station_.StairsDown)
            {
                ///<summary>
                ///左の線
                /// </summary>
                DrawContext.DrawLine(
                    new Pen(Brushes.Black, 1),
                    new Point(stairsDown.PositionX - stairsDown.Width / 2, stairsDown.PositionY - stairsDown.Height / 2),
                    new Point(stairsDown.PositionX - stairsDown.Width / 2, stairsDown.PositionY + stairsDown.Height - stairsDown.Height / 2));

                ///<summary>
                ///右の線
                /// </summary>
                DrawContext.DrawLine(
                    new Pen(Brushes.Black, 1),
                    new Point(stairsDown.PositionX+stairsDown.Width - stairsDown.Width / 2, stairsDown.PositionY - stairsDown.Height / 2),
                    new Point(stairsDown.PositionX+stairsDown.Width - stairsDown.Width / 2, stairsDown.PositionY + stairsDown.Height - stairsDown.Height / 2));

                ///<summary>
                ///下の線
                /// </summary>
                DrawContext.DrawLine(
                    new Pen(Brushes.Black, 1),
                    new Point(stairsDown.PositionX - stairsDown.Width / 2, stairsDown.PositionY+stairsDown.Height - stairsDown.Height / 2),
                    new Point(stairsDown.PositionX + stairsDown.Width - stairsDown.Width / 2, stairsDown.PositionY + stairsDown.Height - stairsDown.Height / 2));
            }

            //出口の描画
            foreach (var goal in station_.Goals)
            {
                DrawContext.DrawRectangle(
                    Brushes.Red,
                    null,
                    new Rect(goal.PositionX - goal.Width / 2 , goal.PositionY - goal.Height / 2 , goal.Width, goal.Height));
            }

            //ベンチの描画
            foreach (var bench in station_.Benchs)
            {
                DrawContext.DrawRectangle(
                    Brushes.Red,
                    null,
                    new Rect(bench.PositionX - bench.Width / 2 , bench.PositionY - bench.Height / 2 , bench.Width, bench.Height));
            }



            DrawContext.Close();

            //表示する画像を更新 
            Bitmap.Render(DrawVisual);
        }

    }
}

