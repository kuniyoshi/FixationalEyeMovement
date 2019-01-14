namespace FixationalEyeMovement
{

    public class Direction
    {

        const float Positive = +1f;

        const float Negative = -1f;

        public float Value => _isPositive
            ? Positive
            : Negative;

        bool _isPositive;

        public Direction()
        {
            _isPositive = true;
        }

        public void ChangeDirection()
        {
            _isPositive = !_isPositive;
        }

    }

}
