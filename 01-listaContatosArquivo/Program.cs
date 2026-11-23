var path = @"C:\dev\";
var file = "contatos.cont";
var listaContatos = new List<Contato>();


bool PathValidation(string p)
{
    try
    {
        Directory.CreateDirectory(p);
        return true;
    }
    catch (DirectoryNotFoundException e)
    {
        Console.WriteLine(e);
        return false;
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        return false;
    }

}

bool FileValidation(string p)
{
    if (File.Exists(p))
        return true;
    try
    {
        if (PathValidation(p))
        {
            File.Create(p + file).Close();
            return true;
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        return false;
    }
    return false;
}

void ShowPhrases()
{
    var reader = new StreamReader(path + file);

    Console.WriteLine(reader.ReadToEnd());

    reader.Close();
}

void SaveSimple(string s)
{
    File.AppendAllText(path + file, s + Environment.NewLine);
}

int MainMenu()
{
    Console.WriteLine("1 - Adicionar contato na lista.");
    Console.WriteLine("2 - Mostrar lista ainda não salva.");
    Console.WriteLine("3 - Salvar lista no arquivo.");
    Console.WriteLine("4 - Mostrar contatos salvos.");
    Console.WriteLine("0 - Sair.");
    return int.Parse(Console.ReadLine());
}

while (true)
{
    switch (MainMenu())
    {
        case 1:
            Console.WriteLine("Nome do contato: ");
            string nomeContato = Console.ReadLine();
            Console.WriteLine("Telefone do contato: ");
            string telefoneContato = Console.ReadLine();
            Console.WriteLine("Endereco do contato: ");
            string enderecoContato = Console.ReadLine();

            Contato contato = new Contato(nomeContato,telefoneContato,enderecoContato);
            listaContatos.Add(contato);
            break;
        case 2:
            if (listaContatos.Count != 0)
            {
                foreach (Contato item in listaContatos)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else
                Console.WriteLine("lista para salvar esta vazia.");

            break;
        case 3:
            if (listaContatos.Count != 0)
            {
                foreach (Contato item in listaContatos)
                {
                    string contatoString = $"{item.Nome},{item.Telefone},{item.Endereco}";
                    SaveSimple(contatoString);
                }

            }
            else
                Console.WriteLine("lista para salvar esta vazia.");
            
            listaContatos.Clear();

            break;
        case 4:
            //buscar do arquivo e salvar na lista de contatos para usar o toString
            var reader = new StreamReader(path + file);
            string linha;
            listaContatos.Clear();

            while ((linha = reader.ReadLine()) != null)
            {
                string[] vetContato = linha.Split(',');
                Contato item = new Contato(vetContato[0], vetContato[1], vetContato[2]);
                Console.WriteLine(item.ToString());
            }
            break;
        case 0:
            Console.WriteLine("Hasta la vista, baby!");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Não entendi!");
            break;
    }
}