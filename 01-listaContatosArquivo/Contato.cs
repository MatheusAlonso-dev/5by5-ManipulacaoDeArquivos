public class Contato
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }

    public Contato(string nome, string telefone, string endereco)
    {
        Nome = nome;
        Telefone = telefone;
        Endereco = endereco;
    }
    public override string ToString()
    {
        return $"Nome: {Nome}\nTelefone: {Telefone}\nEndereco: {Endereco}\n----------------------\n";
    }
}
