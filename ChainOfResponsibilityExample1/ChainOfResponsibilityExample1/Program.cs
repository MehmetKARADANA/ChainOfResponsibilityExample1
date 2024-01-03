internal class Program
{
    private static void Main(string[] args)
    {
        //zinciri oluşturacak halkaları tanımlıyoruz
        PlayerHandler mp4Player = new concreteHandlerMp4();
        PlayerHandler mpgPlayer=new concreteHandlerMpg();
        PlayerHandler aviPlayer=new concreteHandlerAvi();

        //zincir halkalarını sıralıyooruz
        mp4Player.NextHandler(mpgPlayer);
        mpgPlayer.NextHandler(aviPlayer);

        mp4Player.Play("video.mpg");
        mp4Player.Play("video.avi");
        mp4Player.Play("video.mp4");
        mp4Player.Play("video.mdsnk");


    }
}

abstract class PlayerHandler {
    protected PlayerHandler _NextHandler;

    public PlayerHandler NextHandler(PlayerHandler nextHandler) {

        _NextHandler = nextHandler;
        return _NextHandler;
    }

    public abstract void Play(string filePath);

}
class concreteHandlerMp4 : PlayerHandler
{
    public override void Play(string filePath)
    {
        if (filePath.EndsWith(".mp4")) {
            Console.WriteLine("{0} dosyası oyantılıyor(mp4 player)...",filePath);
        }else if (_NextHandler!=null ) { 
        
            _NextHandler.Play(filePath);
        }
        else { Console.WriteLine("geçerli oynatıcı bulunamadı..."); }
        
    }
}
class concreteHandlerMpg:PlayerHandler{
    public override void Play(string filePath)
    {
        if (filePath.EndsWith(".mpg"))
        {
            Console.WriteLine("{0} dosyası oyantılıyor(mpg player)...", filePath);
        }
        else if (_NextHandler != null)
        {

            _NextHandler.Play(filePath);
        }
        else { Console.WriteLine("geçerli oynatıcı bulunamadı..."); }

    }
}
class concreteHandlerAvi : PlayerHandler{
    public override void Play(string filePath)
    {
        if (filePath.EndsWith(".avi"))
        {
            Console.WriteLine("{0} dosyası oyantılıyor(avi player)...", filePath);
        }
        else if (_NextHandler != null)
        {

            _NextHandler.Play(filePath);
        }
        else { Console.WriteLine("geçerli oynatıcı bulunamadı..."); }

    }
}