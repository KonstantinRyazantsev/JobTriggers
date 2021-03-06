﻿using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Lykke.JobTriggers.Triggers.Bindings
{
	public abstract class BaseTriggerBinding : ITriggerBinding
	{
		public abstract void InitBinding(IServiceProvider serviceProvider, MethodInfo callbackMethod);
		public abstract Task RunAsync(CancellationToken cancellationToken);

		protected Task Invoke(IServiceProvider serviceProvider, MethodInfo method, params object[] parameters)
		{
			var instance = serviceProvider.GetService(method.DeclaringType);
			var result = method.Invoke(instance, parameters);
			var task = result as Task;
			return task ?? Task.CompletedTask;
		}
	}
}
