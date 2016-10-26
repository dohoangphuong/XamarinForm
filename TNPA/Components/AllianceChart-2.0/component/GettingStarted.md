
###Quick Start Guide


Add the **AllianceChart.dll** to the References

**Import AllianceChart**
	
	using Alliance.Charts;

**Create Instance for AllianceChart Classes**

	public AllianceChart AllianceChart { get; set;}

**Create object for AllianceChart by Passing ChartType and the View in which chart need to be populated.**

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.AllianceChart = new AllianceChart (Chart.Bar,this.View);
			createBarChart();

			this.View.SetNeedsDisplay ();
		}

**Pie Chart**

	this.AllianceChart = new AllianceChart (Chart.Pie,this.View);
	createPieChart();
	
	
**Line Chart**

	this.AllianceChart = new AllianceChart (Chart.Line,this.View);
	createLineChart();


**Configure Bar Chart**

	public void createBarChart()
	{
		
		AllianceChart.BarChart.SetupBarViewShape(BarShape.Rounded);
		AllianceChart.BarChart.SetupBarViewStyle(BarDisplayStyle.BarStyleMatte);
		AllianceChart.BarChart.SetupBarViewShadow(BarShadow.Light);
		AllianceChart.BarChart.barWidth = 30;

		List<ChartComponent> Components = new List<ChartComponent>();
			
		ChartComponent ChartComponent = new ChartComponent ();
		ChartComponent.Name = "Title 1";
		ChartComponent.value = 45.0f;
		ChartComponent.color = UIColor.FromRGB (135f/255f,227f/255f,23f/255f);
		ChartComponent.lableColor = UIColor.Black;
		Components.Add (ChartComponent);
			
		//Add more ChartComponent for more Bars
		
		AllianceChart.LoadChart (Components, Chart.Bar, this.View);

	}
	
**Configure Pie Chart**

	public void createPieChart()
	{
		List<ChartComponent> Components = new List<ChartComponent>();
		
		ChartComponent ChartComponent = new ChartComponent ();
		ChartComponent.Name = "AAA";
		ChartComponent.value = 12.0f;
		ChartComponent.color = UIColor.FromRGBA (1.0f, 220f / 255.0f, 0.0f, 1.0f);
		Components.Add (ChartComponent);
		
		//Add more ChartComponent for more Slices in Pie Chart

		AllianceChart.LoadChart (Components, Chart.Pie, this.View);
	}


**Configure Line Chart**

	public void createLineChart()
	{
		List<string> X_labels = new List<string>{"Jan","Feb","Mar","Apr","May","Jun"};
		AllianceChart.LineChartView.XLabels = X_labels;
		AllianceChart.LineChartView.PopOverTextColor = UIColor.White;
		List<ChartComponent> components = new List<ChartComponent>();
		
		ChartComponent ChartComponent = new ChartComponent ();
		ChartComponent.Name = "Smith";
		ChartComponent.valueList = new List<float?>{20f,10f,35f,45f,69f,70f};
		ChartComponent.color = UIColor.FromRGB (23f/255f,169f/255f,227f/255f);
		ChartComponent.lableColor = UIColor.Black;
		components.Add (ChartComponent);
		
		// Add more ChartComponent for more Lines in the Line Chart
		
		AllianceChart.LoadChart (components, Chart.Line, this.View);

	}

**Customize Bar Chart**

Customize the Bar Chart Shape, Style, Shadow and BarWidth

	AllianceChart.BarChart.SetupBarViewShape(BarShape.Rounded);
	AllianceChart.BarChart.SetupBarViewStyle(BarDisplayStyle.BarStyleMatte);	AllianceChart.BarChart.SetupBarViewShadow(BarShadow.Light);	AllianceChart.BarChart.barWidth = 30;
	
**Customize Pie Chart**

	//To show value color same as PieChart slice color
	AllianceChart.PieChart.SameColorLabel = true; 
	
	//To customize Font of Name given to slice
	AllianceChart.PieChart.TitleFont = UIFont.FromName ("HelveticaNeue-Bold",15f);
	
	//To customize Font of Value given to slice 
	AllianceChart.PieChart.PercentageFont = UIFont.FromName ("HelveticaNeue-Bold",15f);
	
	//To show arrow to from the PieChart slice to value. By default it will be true
	AllianceChart.PieChart.ShowArrow = false;
	
	//To draw outline for the PieChart. By default it will be true
	AllianceChart.PieChart.Outline = false;
	
	//To set color to Arrow
	AllianceChart.PieChart.ArrowColor = UIColor.Black;
	
	//To show value or calculate and show percentange value of slice
	AllianceChart.PieChart.ShowPercentage = false;

**Customize Line Chart**

	//You can set your own image for PopOver to show values 
	AllianceChart.LineChartView.PopOverImage = UIImage.FromFile ("bg_tooltip.png");
	
	//To Set PopOver TextColor 
	AllianceChart.LineChartView.PopOverTextColor = UIColor.White;
	
	//To set background color 
	AllianceChart.LineChartView.BackgroundColor = UIColor.White;
	
	//To set number of intervals required in the Chart.
	AllianceChart.LineChartView.Interval = 10;
	
	//To set max limit.
	AllianceChart.LineChartView.MaxValue = 100;
	
	//To set min limit.
	AllianceChart.LineChartView.MinValue = 0;
	
	//To set Y-axis Label Font 
	AllianceChart.LineChartView.YLabelFont = UIFont.SystemFontOfSize(12);
	
	//To set X-axis Label Font
	AllianceChart.LineChartView.XLabelFont = UIFont.BoldSystemFontOfSize(12);
	
	//To set Font for the Value shown on Line Chart
	AllianceChart.LineChartView.ValueLabelFont = UIFont.BoldSystemFontOfSize(10);
	
	//To set Font for Legend Value
	AllianceChart.LineChartView.LegendFont = UIFont.BoldSystemFontOfSize(10);
	
	//To set Y-axis Lave Allignment
	AllianceChart.LineChartView.YLabelAlignment = UITextAlignment.Right;
	
	//To set Color to X-axis and Y-axis
	AllianceChart.LineChartView.AxisColor = UIColor.Black;





