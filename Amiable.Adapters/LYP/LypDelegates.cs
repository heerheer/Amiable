namespace Amiable.Adapters.LYP
{
    public class LypDelegates
    {
        public delegate int SendGroupMsgDelegate(long group,string msg,string appid);
        public delegate int SendPriMsgDelegate(long qq,string msg,string appid);
    }
}