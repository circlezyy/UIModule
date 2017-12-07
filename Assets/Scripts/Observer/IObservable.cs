using UnityEngine;
using System.Collections;
namespace Observer.Core
{
	public interface IObservable
	{
		IObservable AddObserver(IObserver observer);
		IObservable RemoveObserver(IObserver observer);
		void Publish (string notification, object sender, object data = null);
	}
}
