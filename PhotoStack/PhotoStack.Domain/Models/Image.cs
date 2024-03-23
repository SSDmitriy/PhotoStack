namespace PhotoStack.Domain.Models
{
    public class Image
    {
        public string FilePath { get; }

        //ориентация картинки
        //ширина
        //высота

        public Image(string filePath)
        {
            FilePath = filePath;
        }

        //добавить валидацию к Image, с методом Create и типом Result
        //можно проверять расширение
        //можно проверять размер картинки в пикселях
    }
}
