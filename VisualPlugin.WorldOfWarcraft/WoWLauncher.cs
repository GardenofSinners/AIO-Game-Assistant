using Livet;
using System.ComponentModel.Composition;
using VisualPlugin.Interfaces;

namespace VisualPlugin.Sample1
{
    [Export(typeof(IVisualPlugin))]
	public class WoWLauncher : NotificationObject, IVisualPlugin
	{
		#region Name 変更通知プロパティ

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

		#endregion

		public string Message { get; set; }


		public WoWLauncher()
		{
			this.Name = "World of Warcraft";
		}

		public void Proc()
		{
            WorldofWarcraft WoW = new WorldofWarcraft();
            WoW.ShowDialog();
        }
	}
}
