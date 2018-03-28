# AIO-Game-Assistant

Instructions on how to add Modules: (WPF version to replace Winforms soon)

1. Create a new Class Library project in the directory labelling it VisualPlugin.GameNameHere
![Image of creating a new project](https://i.imgur.com/6iiI526.png)
2. Rename Class1.cs to whatever you want the plugin loader to be called eg DiabloLauncher.cs
3. Right click the Project Directory you made and click on Manage Nuget Packages. Install LivetCask and close Nuget.
![Image of Nuget Packages with LivetCask installed](https://i.imgur.com/k8FEWGC.png)
4. Replace the code inside your .cs file with the following code:
```c#
using System.ComponentModel.Composition;
using Livet;
using VisualPlugin.Interfaces;

namespace VisualPlugin.GameNameHere
{
	[Export(typeof(IVisualPlugin))]
	public class NameOfCSFileHere : NotificationObject, IVisualPlugin
	{
  
		private string _Name;

		public string Name
		{
			get { return this._Name; }
			set
			{
				if (this._Name != value)
				{
					this._Name = value;
					this.RaisePropertyChanged();
				}
			}
		}

		public string Message { get; set; }


		public NameOfCSFileHere()
		{
			this.Name = "Title of the Plugin on the main screen";
		}

		public Proc(){
                //Your code to run the window where all the stuff will be at eg
                SomeFormName formName = new SomeFormName();
                formName.ShowDialog();
        	}
	}
}
```
6. Right click your project and click on properties -> Click the Build Tab -> and replace whatevers in the "Output Path" with ..\VisualPlugin.UI\bin\Debug\Plugin\
![Image of Build Tab in Properties](https://i.imgur.com/pIzpxFT.png)
7. Save and close Project Properties.
8. Done, now make your plugin to your hearts content :)
