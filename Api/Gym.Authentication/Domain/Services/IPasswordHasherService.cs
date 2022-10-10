namespace Gym.Authentication.Domain.Services
{
    public interface IPasswordHasherService
    {
        /// <summary>
        /// Cria um hash a partir da senha informada
        /// </summary>
        /// <param name="password">Senha a ser criptografada</param>
        /// <returns>Uma string com o hash da senha informada</returns>
        string Hash(string password);

        /// <summary>
        /// Faz a validacão da senha
        /// </summary>
        /// <param name="hash">Hash salva no banco de dados</param>
        /// <param name="password">Senha a ser testada</param>
        /// <returns>Objeto com a propriedade Verified indiciando se a validação foi bem sucedida e com a propriedade NeedsUpgrade
        /// que indica se a senha precisa ser atualizada</returns>
        (bool Verified, bool NeedsUpgrade) Check(string hash, string password);
    }
}
