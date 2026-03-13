using System;
using System.IO;

// README.md를 읽고 아래에 코드를 작성하세요.
Console.WriteLine("=== 경로 검증 테스트 ===");
FilePathValidator file = new FilePathValidator();

file.ValidatePath("");
file.ValidatePath("");
file.ValidatePath("");
file.ValidatePath("");

class FilePathValidator
{

    public void ValidatePath(string path)
    {
        string [] strs = {"<", ">", "|", "\"", "*", "?"};
        try
        {
            Console.WriteLine($"경로가 유효합니다: {path}");
        }
        catch (ArgumentNullException ex) when (path == null) 
        {
            Console.WriteLine($"[{(ex)} 오류]경로는 null이거나 비어있을 수 없습니다.");
        }
        catch (ArgumentOutOfRangeException ex) when (path.Length > 260)
        {
            Console.WriteLine($"[{(ex)} 오류]경로 길이가 260자를 초과합니다.");
        }
        catch (ArgumentException ex) when (path.Contains("<") || path.Contains(">") || path.Contains("?") || path.Contains("|") || path.Contains("\"") || path.Contains("*"))
        {
            foreach(string str in strs)
            {
                if (path.Contains(str))
                {
                    Console.WriteLine($"[{(ex)} 오류] {str}'가 포함되어 있습니다.");
                    break;
                }
            }
        }
    }

    public void ValidateExtension(string path, string[] allowedExtensions)
    {
        try
        {
            foreach (string extension in allowedExtensions)
            {
                if (path.Contains(extension))
                {
                    Console.WriteLine($"확장자가 유효합니다: {extension}");
                    break;
                }
                
            }
        }
        catch(ArgumentException)
        {

        }
    }
}