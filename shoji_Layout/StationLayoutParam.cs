using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shoji_Layout
{
    /// <summary>
    /// 改札の情報クラス
    /// </summary>
    public class StationKaisatuParam
    {
        /// <summary>
        /// 改札の横幅
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// 改札の縦幅
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// 改札のX座標
        /// </summary>
        public double PositionX { get; set; }

        /// <summary>
        /// 改札のY座標
        /// </summary>
        public double PositionY { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="width">改札の縦幅</param>
        /// <param name="height">改札の横幅</param>
        /// <param name="positionX">改札のX座標</param>
        /// <param name="positionY">改札のY座標</param>
        public StationKaisatuParam(double width, double height, double positionX, double positionY)
        {
            Height = height;
            Width = width;
            PositionX = positionX;
            PositionY = positionY;
        }

    }

    /// <summary>
    /// エレベーターの情報クラス
    /// </summary>
    public class StationElevatorParam
    {
        /// <summary>
        /// エレベーターの横幅
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// エレベーターの縦幅
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// エレベーターのX座標
        /// </summary>
        public double PositionX { get; set; }

        /// <summary>
        /// エレベーターのY座標
        /// </summary>
        public double PositionY { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="width">エレベーターの縦幅</param>
        /// <param name="height">エレベーターの横幅</param>
        /// <param name="positionX">エレベーターのX座標</param>
        /// <param name="positionY">エレベーターのY座標</param>
        public StationElevatorParam(double width, double height, double positionX, double positionY)
        {
            Height = height;
            Width = width;
            PositionX = positionX;
            PositionY = positionY;
        }

    }

    /// <summary>
    /// 駅員室の情報クラス
    /// </summary>
    public class StationRoomParam
    {
        /// <summary>
        /// 駅員室の横幅
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// 駅員室の縦幅
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// 駅員室のX座標
        /// </summary>
        public double PositionX { get; set; }

        /// <summary>
        /// 駅員室のY座標
        /// </summary>
        public double PositionY { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="width">駅員室の縦幅</param>
        /// <param name="height">駅員室の横幅</param>
        /// <param name="positionX">駅員室のX座標</param>
        /// <param name="positionY">駅員室のY座標</param>
        public StationRoomParam(double width, double height, double positionX, double positionY)
        {
            Height = height;
            Width = width;
            PositionX = positionX;
            PositionY = positionY;
        }

    }

    /// <summary>
    /// 階段の情報クラス
    /// </summary>
    public class StationStairsParam
    {
        /// <summary>
        /// 階段の横幅
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// 階段の縦幅
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// 階段のX座標
        /// </summary>
        public double PositionX { get; set; }

        /// <summary>
        /// 階段のY座標
        /// </summary>
        public double PositionY { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="width">階段の縦幅</param>
        /// <param name="height">階段の横幅</param>
        /// <param name="positionX">階段のX座標</param>
        /// <param name="positionY">階段のY座標</param>
        public StationStairsParam(double width, double height, double positionX, double positionY)
        {
            Height = height;
            Width = width;
            PositionX = positionX;
            PositionY = positionY;
        }

    }

    /// <summary>
    /// 出口の情報クラス
    /// </summary>
    public class StationGoalParam
    {
        /// <summary>
        /// 出口の横幅
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// 出口の縦幅
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// 出口のX座標
        /// </summary>
        public double PositionX { get; set; }

        /// <summary>
        /// 出口のY座標
        /// </summary>
        public double PositionY { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="width">出口の縦幅</param>
        /// <param name="height">出口の横幅</param>
        /// <param name="positionX">出口のX座標</param>
        /// <param name="positionY">出口のY座標</param>
        public StationGoalParam(double width, double height, double positionX, double positionY)
        {
            Height = height;
            Width = width;
            PositionX = positionX;
            PositionY = positionY;
        }

    }

    /// <summary>
    /// ベンチの情報クラス
    /// </summary>
    public class StationBenchParam
    {
        /// <summary>
        /// ベンチの横幅
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// ベンチの縦幅
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// ベンチのX座標
        /// </summary>
        public double PositionX { get; set; }

        /// <summary>
        /// ベンチのY座標
        /// </summary>
        public double PositionY { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="width">ベンチの縦幅</param>
        /// <param name="height">ベンチの横幅</param>
        /// <param name="positionX">ベンチのX座標</param>
        /// <param name="positionY">ベンチのY座標</param>
        public StationBenchParam(double width, double height, double positionX, double positionY)
        {
            Height = height;
            Width = width;
            PositionX = positionX;
            PositionY = positionY;
        }

    }

    /// <summary>
    /// 柱の情報クラス
    /// </summary>
    public class StationPillarParam
    {
        /// <summary>
        /// 柱の横幅
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// 柱の縦幅
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// 柱のX座標
        /// </summary>
        public double PositionX { get; set; }

        /// <summary>
        /// 柱のY座標
        /// </summary>
        public double PositionY { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="width">柱の縦幅</param>
        /// <param name="height">柱の横幅</param>
        /// <param name="positionX">柱のX座標</param>
        /// <param name="positionY">柱のY座標</param>
        public StationPillarParam(double width, double height, double positionX, double positionY)
        {
            Height = height;
            Width = width;
            PositionX = positionX;
            PositionY = positionY;
        }

    }

    /// <summary>
    /// 自動販売機の情報クラス
    /// </summary>
    public class StationDrinkParam
    {
        /// <summary>
        /// 自動販売機の横幅
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// 自動販売機の縦幅
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// 自動販売機のX座標
        /// </summary>
        public double PositionX { get; set; }

        /// <summary>
        /// 自動販売機のY座標
        /// </summary>
        public double PositionY { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="width">自動販売機の縦幅</param>
        /// <param name="height">自動販売機の横幅</param>
        /// <param name="positionX">自動販売機のX座標</param>
        /// <param name="positionY">自動販売機のY座標</param>
        public StationDrinkParam(double width, double height, double positionX, double positionY)
        {
            Height = height;
            Width = width;
            PositionX = positionX;
            PositionY = positionY;
        }

    }

    /// <summary>
    /// 駅のレイアウトクラス
    /// </summary>
    public class StationLayoutParam
    {

        /// <summary>
        /// レイアウトの横幅
        /// </summary>
        public int Width { get; set; } = 1000;

        /// <summary>
        /// レイアウトの縦幅
        /// </summary>
        public int Height { get; set; } = 1000;

        /// <summary>
        /// 改札のリスト）
        /// </summary>
        public List<StationKaisatuParam> Kaisatus { get; set; } = new List<StationKaisatuParam>();

        /// <summary>
        /// エレベーターのリスト
        /// </summary>
        public List<StationElevatorParam> Elevators { get; set; } = new List<StationElevatorParam>();

        /// <summary>
        /// 駅員室のリスト）
        /// </summary>
        public List<StationRoomParam> Rooms { get; set; } = new List<StationRoomParam>();

        /// <summary>
        /// 階段のリスト
        /// </summary>
        public List<StationStairsParam> Stairss { get; set; } = new List<StationStairsParam>();

        /// <summary>
        /// 出口のリスト
        /// </summary>
        public List<StationGoalParam> Goals { get; set; } = new List<StationGoalParam>();

        /// <summary>
        /// ベンチのリスト）
        /// </summary>
        public List<StationBenchParam> Benchs { get; set; } = new List<StationBenchParam>();

        /// <summary>
        /// 柱のリスト
        /// </summary>
        public List<StationPillarParam> Pillars { get; set; } = new List<StationPillarParam>();

        /// <summary>
        /// 自動販売機のリスト
        /// </summary>
        public List<StationDrinkParam> Drinks { get; set; } = new List<StationDrinkParam>();

    }

}
