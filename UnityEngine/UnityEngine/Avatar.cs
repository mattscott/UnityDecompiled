using System;
using System.Runtime.CompilerServices;
using UnityEngine.Scripting;

namespace UnityEngine
{
	[UsedByNativeCode]
	public class Avatar : Object
	{
		public extern bool isValid
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public extern bool isHuman
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		private Avatar()
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern void SetMuscleMinMax(int muscleId, float min, float max);

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern void SetParameter(int parameterId, float value);

		internal float GetAxisLength(int humanId)
		{
			return this.Internal_GetAxisLength(HumanTrait.GetBoneIndexFromMono(humanId));
		}

		internal Quaternion GetPreRotation(int humanId)
		{
			return this.Internal_GetPreRotation(HumanTrait.GetBoneIndexFromMono(humanId));
		}

		internal Quaternion GetPostRotation(int humanId)
		{
			return this.Internal_GetPostRotation(HumanTrait.GetBoneIndexFromMono(humanId));
		}

		internal Quaternion GetZYPostQ(int humanId, Quaternion parentQ, Quaternion q)
		{
			return this.Internal_GetZYPostQ(HumanTrait.GetBoneIndexFromMono(humanId), parentQ, q);
		}

		internal Quaternion GetZYRoll(int humanId, Vector3 uvw)
		{
			return this.Internal_GetZYRoll(HumanTrait.GetBoneIndexFromMono(humanId), uvw);
		}

		internal Vector3 GetLimitSign(int humanId)
		{
			return this.Internal_GetLimitSign(HumanTrait.GetBoneIndexFromMono(humanId));
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern float Internal_GetAxisLength(int humanId);

		internal Quaternion Internal_GetPreRotation(int humanId)
		{
			Quaternion result;
			this.Internal_GetPreRotation_Injected(humanId, out result);
			return result;
		}

		internal Quaternion Internal_GetPostRotation(int humanId)
		{
			Quaternion result;
			this.Internal_GetPostRotation_Injected(humanId, out result);
			return result;
		}

		internal Quaternion Internal_GetZYPostQ(int humanId, Quaternion parentQ, Quaternion q)
		{
			Quaternion result;
			this.Internal_GetZYPostQ_Injected(humanId, ref parentQ, ref q, out result);
			return result;
		}

		internal Quaternion Internal_GetZYRoll(int humanId, Vector3 uvw)
		{
			Quaternion result;
			this.Internal_GetZYRoll_Injected(humanId, ref uvw, out result);
			return result;
		}

		internal Vector3 Internal_GetLimitSign(int humanId)
		{
			Vector3 result;
			this.Internal_GetLimitSign_Injected(humanId, out result);
			return result;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Internal_GetPreRotation_Injected(int humanId, out Quaternion ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Internal_GetPostRotation_Injected(int humanId, out Quaternion ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Internal_GetZYPostQ_Injected(int humanId, ref Quaternion parentQ, ref Quaternion q, out Quaternion ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Internal_GetZYRoll_Injected(int humanId, ref Vector3 uvw, out Quaternion ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Internal_GetLimitSign_Injected(int humanId, out Vector3 ret);
	}
}
