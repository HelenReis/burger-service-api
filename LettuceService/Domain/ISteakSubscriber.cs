namespace LettuceService.Domain
{
    public interface ILettuceSubscriber 
    {
        public void ListenToMessage();
    }
}