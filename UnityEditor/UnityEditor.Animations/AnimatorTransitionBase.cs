using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace UnityEditor.Animations
{
	public class AnimatorTransitionBase : UnityEngine.Object
	{
		private PushUndoIfNeeded undoHandler = new PushUndoIfNeeded(true);

		public extern bool solo
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		public extern bool mute
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		public extern bool isExit
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		public extern AnimatorStateMachine destinationStateMachine
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		public extern AnimatorState destinationState
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		public extern AnimatorCondition[] conditions
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall)]
			set;
		}

		internal bool pushUndo
		{
			set
			{
				this.undoHandler.pushUndo = value;
			}
		}

		protected AnimatorTransitionBase()
		{
		}

		public string GetDisplayName(UnityEngine.Object source)
		{
			return (!(source is AnimatorState)) ? this.GetDisplayNameStateMachineSource(source as AnimatorStateMachine) : this.GetDisplayNameStateSource(source as AnimatorState);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern string GetDisplayNameStateSource(AnimatorState source);

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern string GetDisplayNameStateMachineSource(AnimatorStateMachine source);

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern string BuildTransitionName(string source, string destination);

		public void AddCondition(AnimatorConditionMode mode, float threshold, string parameter)
		{
			this.undoHandler.DoUndo(this, "Condition added");
			AnimatorCondition[] conditions = this.conditions;
			ArrayUtility.Add<AnimatorCondition>(ref conditions, new AnimatorCondition
			{
				mode = mode,
				parameter = parameter,
				threshold = threshold
			});
			this.conditions = conditions;
		}

		public void RemoveCondition(AnimatorCondition condition)
		{
			this.undoHandler.DoUndo(this, "Condition removed");
			AnimatorCondition[] conditions = this.conditions;
			ArrayUtility.Remove<AnimatorCondition>(ref conditions, condition);
			this.conditions = conditions;
		}
	}
}
