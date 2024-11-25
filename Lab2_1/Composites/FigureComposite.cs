using Lab2_1.Decorator;
using SFML.Graphics;
using SFML.System;

namespace Lab2_1.Composites
{
    public class FigureComposite : BaseFigureDecorator
    {
        private readonly List<BaseFigureDecorator> _figures = new();

        public FigureComposite() { }

        public void Add( BaseFigureDecorator figure )
        {
            _figures.Add(figure);
        }

        /*public void Add( FigureComposite figureComposite )
        {
            foreach (var figure in figureComposite.GetFigures())
            {
                Console.WriteLine(figure);
                _figures.Add(figure);
            }
        }*/

        public override void Draw( RenderWindow window )
        {
            foreach (var figure in _figures)
            {
                figure.Draw(window);
            }
        }

        public override FloatRect GetGlobalBounds()
        {
            float left = float.MaxValue, top = float.MaxValue;
            float right = float.MinValue, bottom = float.MinValue;

            foreach (BaseFigureDecorator figure in _figures)
            {
                var bounds = figure.GetGlobalBounds();
                if (bounds.Left < left) left = bounds.Left;
                if (bounds.Top < top) top = bounds.Top;
                if (bounds.Left + bounds.Width > right) right = bounds.Left + bounds.Width;
                if (bounds.Top + bounds.Height > bottom) bottom = bounds.Top + bounds.Height;
            }

            float width = right - left;
            float height = bottom - top;

            return new FloatRect(left, top, width, height);
        }

        public override void SetPosition( float x, float y )
        {
            if (_figures.Count == 0)
            {
                return; // Если композит пуст, ничего не делаем
            }

            // Получаем текущую позицию композита
            Vector2f currentPosition = GetPosition();

            // Вычисляем смещение
            float deltaX = x - currentPosition.X;
            float deltaY = y - currentPosition.Y;

            // Применяем смещение ко всем фигурам в композите
            foreach (var figure in _figures)
            {
                Vector2f figurePosition = figure.GetPosition();
                figure.SetPosition(figurePosition.X + deltaX, figurePosition.Y + deltaY);
            }
        }

        public override Vector2f GetPosition()
        {
            if (_figures.Count == 0)
            {
                return new Vector2f(0, 0); // Или выбросить исключение, если композит не имеет фигур
            }

            // Инициализируем минимальные координаты большими значениями
            float left = float.MaxValue;
            float top = float.MaxValue;

            // Перебираем все фигуры в композите, чтобы найти минимальные координаты
            foreach (var figure in _figures)
            {
                var position = figure.GetPosition();
                if (position.X < left) left = position.X;
                if (position.Y < top) top = position.Y;
            }

            return new Vector2f(left, top);
        }

        public override void SetFillColor( Color color )
        {
            if (_figures.Count == 0)
            {
                return;
            }

            foreach (var figure in _figures)
            {
                figure.SetFillColor(color);
            }
        }

        public override void SetOutlineColor( Color color )
        {
            if (_figures.Count == 0)
            {
                return;
            }

            foreach (var figure in _figures)
            {
                figure.SetOutlineColor(color);
            }
        }


        public List<BaseFigureDecorator> GetFigures()
        {
            return _figures;
        }
    }
}
