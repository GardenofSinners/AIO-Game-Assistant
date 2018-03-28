using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livet;
using VisualPlugin.Interfaces;

namespace VisualPlugin.UI.ViewModels
{
	public class PluginViewModel : ViewModel
	{

		public IVisualPlugin Plugin { get; private set; }


		public PluginViewModel(IVisualPlugin plugin)
		{
			this.Plugin = plugin;
		}
	}
}
