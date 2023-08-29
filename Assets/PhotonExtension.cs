using System;
using Photon.Pun;

public static class PhotonExtensions
{
    public static void RPC<T1>(this PhotonView photonView, RpcTarget target, Action<T1> action, T1 arg1)
    {
        string methodName = action.Method.Name;
        photonView.RPC(methodName, target, arg1);
    }
    public static void RPC(this PhotonView photonView, RpcTarget target, Action action)
    {
        string methodName = action.Method.Name;
        photonView.RPC(methodName, target);
    }

    public static void RPC<T1, T2>(this PhotonView photonView, RpcTarget target, Action<T1, T2> action, T1 arg1, T2 arg2)
    {
        string methodName = action.Method.Name;
        photonView.RPC(methodName, target, arg1, arg2);
    }

    public static void RPC<T1, T2, T3>(this PhotonView photonView, RpcTarget target, Action<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3)
    {
        string methodName = action.Method.Name;
        photonView.RPC(methodName, target, arg1, arg2, arg3);
    }

    public static void RPC<T1, T2, T3, T4>(this PhotonView photonView, RpcTarget target, Action<T1, T2, T3, T4> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
        string methodName = action.Method.Name;
        photonView.RPC(methodName, target, arg1, arg2, arg3, arg4);
    }

    public static void RPC<T1, T2, T3, T4, T5>(this PhotonView photonView, RpcTarget target, Action<T1, T2, T3, T4, T5> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
    {
        string methodName = action.Method.Name;
        photonView.RPC(methodName, target, arg1, arg2, arg3, arg4, arg5);
    }

    public static void RPC<T1, T2, T3, T4, T5, T6>(this PhotonView photonView, RpcTarget target, Action<T1, T2, T3, T4, T5, T6> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
    {
        string methodName = action.Method.Name;
        photonView.RPC(methodName, target, arg1, arg2, arg3, arg4, arg5, arg6);
    }

    public static void RPC<T1, T2, T3, T4, T5, T6, T7>(this PhotonView photonView, RpcTarget target, Action<T1, T2, T3, T4, T5, T6, T7> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
    {
        string methodName = action.Method.Name;
        photonView.RPC(methodName, target, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
    }
}