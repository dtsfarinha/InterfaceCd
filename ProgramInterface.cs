///////////////////////////////// Exerc�cio que ilustra a utiliza��o de Interfaces 

using System;
using System.Collections.Generic;

///////////////////////////////// Classe que representa um CD 

class CD
{
    private string FaixaAudio;
    private string FaixaVideo;
    private int NumFaixa ;      //NumFaixa foi criado para se poder diferenciar mais facilmente cada CD. Uso Como se fosse uma chave primaria.

    public CD(string FaixaAudio, string FaixaVideo, int NumFaixa)
    {
        this.FaixaAudio = FaixaAudio;
        this.FaixaVideo = FaixaVideo;
        this.NumFaixa = NumFaixa;
    }

/////////////////////////////// Variaveis incorporadas no objeto CD

    public string Audio()
    {
        return FaixaAudio;
    }

    public string Video()
    {
        return FaixaVideo;
    }

    public int Num()
    {
        return NumFaixa;            
    }
}



interface ILeitorCD
{
    void TocaCD(CD cdATocar);
}


/*Nas Classes Computador , Aparelhagem e LeitordeVideo decidi acrescentar dois metodos e um construtor ; o construtor para se poder diferenciar entre os pcs na lista generica, 
 e os dois metodos para se poder mudar o nome ( aplicado mais embaixo, no main). o metodo " changeNome" teve que ser criado porque eu queria iniciar os objetos dentro de um "if"
 e pelos vistos isso nao � possivel. */


class Computador : ILeitorCD
{
    private string nome;
    public Computador(string nome)
    {
        this.nome = nome;
    }
    public string Nomes()
    {
        return nome;
    }
    public void changeNome(string newNome)
    {
        nome = newNome;
    }
    
    public void TocaCD(CD cdATocar)
    {
        Console.WriteLine("\n{0} CD Power Player",nome);
        Console.WriteLine("�udio: {0}", cdATocar.Audio());

        
            Console.WriteLine("Video: {0}", cdATocar.Video());
    }
}



class Aparelhagem : ILeitorCD
{
    private string nome;
    public Aparelhagem(string nome)
    {
        this.nome = nome;
    }
    public string Nomes()
    {
        return nome;
    }
    public void changeNome(string newNome)
    {
        nome = newNome;
    }
    public void TocaCD(CD cdATocar)
    {
        Console.WriteLine("\n{0} a tocar: \n{1}",
                         nome, cdATocar.Audio());
    }
}



class LeitorVideo : ILeitorCD

{
    private string nome;
    public LeitorVideo(string nome)
    {
        this.nome = nome;
    }
    public string Nomes()
    {
        return nome;
    }
    public void changeNome(string newNome)
    {
        nome = newNome;
    }

    public void TocaCD(CD cdATocar)
    {
        Console.WriteLine("\n{0} a tocar : \n{1}",
                        nome,cdATocar.Video());
    }
}


class Programa_Interface
{
    static void Main(string[] args)
    {
       

        List<CD> ListaCDs = new List<CD>();
       


        int Numcd = 1;
        

        string opcao = "Sim";
        while(opcao == "Sim"|| opcao == "sim")      
        {
            Console.WriteLine("\nInsira uma nova faixa \n ");
            
            Console.WriteLine("Audio :\n");
            string Audiocd = Console.ReadLine();

            Console.WriteLine("\nVideo :\n");
            string Videocd = Console.ReadLine();
            
            ListaCDs.Add(new CD(Audiocd,Videocd,Numcd));
            Numcd++;
            
            Console.WriteLine("\nDeseja inserir {0}� faixa? Sim/Nao \n",Numcd);
            opcao = Console.ReadLine();

        }

      /////////////////////////// Inicializa�ao das Listas de Computadores, Aparelhagens e Leitores de Video .
        List<Computador> ListaComputadores = new List<Computador>();
        List<Aparelhagem> ListaAparelhagens = new List<Aparelhagem>();
        List<LeitorVideo> ListaLeitoresDeVideo = new List<LeitorVideo>();
        
        ////////////////////////Preenchimento das listas de dispositivos.

        ListaComputadores.Add(new Computador("Pc1"));
        ListaComputadores.Add(new Computador("Pc2"));
        ListaComputadores.Add(new Computador("Pc3"));

        ListaAparelhagens.Add(new Aparelhagem("Aparelhagem1"));
        ListaAparelhagens.Add(new Aparelhagem("Aparelhagem2"));
        ListaAparelhagens.Add(new Aparelhagem("Aparelhagem3"));

        ListaLeitoresDeVideo.Add(new LeitorVideo("LeitorVideo1"));
        ListaLeitoresDeVideo.Add(new LeitorVideo("LeitorVideo2"));
        ListaLeitoresDeVideo.Add(new LeitorVideo("LeitorVideo3"));


        
        
        

        ILeitorCD leitorAlvo;

        // Variaveis que vao ser usadas ////////////

        string Audio = null, Video = null;
        int numberVideo = 0, numberAudio = 0, number = 0;
        string nome = "0";

        // O utilizador escolhe qual a interface a utilizar pc, stereo ou video?
        
        Console.WriteLine("\nQual o dispositivo a usar?" + "(pc/stereo/video)\n");

        

        Computador pc = new Computador(nome);
        LeitorVideo video = new LeitorVideo(nome);
        Aparelhagem stereo = new Aparelhagem(nome);

        string dispositivo = Console.ReadLine();


        //Se o dispositivo for um pc este vai imprimir a lista toda de pcs e pedir para escolher uma.
        if (dispositivo == "pc")
        {
            
            Console.WriteLine("\nEscolha o pc a usar:\n");
            foreach(Computador el in ListaComputadores)
            {
                Console.WriteLine("\n" + el.Nomes() );
            }
             nome = Console.ReadLine();

            
              foreach (Computador el in ListaComputadores)
                {

                    if (nome == el.Nomes())
                    {
                        pc.changeNome(nome);
                    }
                    
                }

              leitorAlvo = pc;

        }

             // se o dispositivo escolhido for um stereo , este vai imprimir a lista com todas as aparelhagens e pedir para escolher uma .

        else if (dispositivo == "stereo")
        {
            
            Console.WriteLine("\nEscolha o Aparelhagem a usar:\n");
            foreach (Aparelhagem el in ListaAparelhagens)
            {
                Console.WriteLine("\n" + el.Nomes());
            }
             nome = Console.ReadLine();


            foreach (Aparelhagem el in ListaAparelhagens)
            {

                if (nome == el.Nomes())
                {

                    stereo.changeNome(nome);
                }       

            }
            leitorAlvo = stereo;
        }

            //se o dispositivo for um video vai imprimir uma lista com todos os leitores de video e pedir para escolher um  .

        else if (dispositivo == "video")
        {

            Console.WriteLine("\nEscolha o Leitor de Video a usar:\n");
            foreach (LeitorVideo el in ListaLeitoresDeVideo)
            {
                Console.WriteLine("\n" + el.Nomes());
            }
             nome = Console.ReadLine();


            foreach (LeitorVideo el in ListaLeitoresDeVideo)
            {

                if (nome == el.Nomes())
                {

                    video.changeNome(nome);
                }

            }
            
            leitorAlvo = video;
            
        }
        else
            leitorAlvo = null;

        // Se o leitor escolhido for um stereo, este vai imprimir a lista Cds so com o audio e vai pedir para esolher o audio para se ouvir .
        
        if ( leitorAlvo == stereo)
        {
            Console.WriteLine("\nEscolha uma faixa Audio \n");

            foreach (CD el in ListaCDs)
            {
                Console.WriteLine("\n"+ el.Num() + " - "+ el.Audio() + "\n");       // Emiss�o da faixa audio e do respetivo n�mero
            }

            numberAudio = int.Parse(Console.ReadLine());

                foreach (CD el in ListaCDs)
                {

                    if (numberAudio == el.Num())
                    {
                        Audio = el.Audio();
                    }
                    
                }
            
        }
        // Se o leitor escolhido for um video, este vai imprimir a lista Cds so com o video e vai pedir para esolher o video para se ver .

        
        if ( leitorAlvo == video)
        {
            Console.WriteLine("\nEscolha uma faixa Video \n");

            foreach (CD element in ListaCDs)
            {
                Console.WriteLine("\n" + element.Num() + " - " + element.Video() + "\n");     // Emiss�o da faixa video e do respetivo n�mero
            }
            
            numberVideo = int.Parse(Console.ReadLine());
            

                foreach (CD el in ListaCDs)
                {

                    if (numberVideo == el.Num())
                    {
                        Video = el.Video();
                    }
                    
                        
                }
            }
        
        

        //Se o leitor escolhido por um pc, vai imprimir a lista de CDs e vai pedir para escolher qual o que se deseja ver.

        if (leitorAlvo == pc)
        {
            Console.WriteLine("\nEscolha uma faixa \n");

            foreach (CD eliment in ListaCDs)
            {
                Console.WriteLine("\n" + eliment.Num() + " -  " + eliment.Audio() + " " + eliment.Video() + "\n");       // Emiss�o da faixa audio e video do respetivo n�mero
            }

            number = int.Parse(Console.ReadLine());

                foreach (CD elo in ListaCDs)
                {
                    
                    if (number == elo.Num())
                    {
                        Audio = elo.Audio();
                        Video = elo.Video();
                    }
                      

                }
            

        }
            //Cria�ao do Cd escolhido para impressao no ecra    

        CD faixa = new CD(Audio, Video, Numcd);

        // escolhido o leitorAlvo, com uma s� instru��o toca-se o CD faixa no leitor indicado
       
        if (leitorAlvo != null)
            leitorAlvo.TocaCD(faixa);
        else
            Console.WriteLine("Dispositivo desconhecido");
    }
}