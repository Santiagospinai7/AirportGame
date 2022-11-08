namespace ComputacionGrafica.Airport
{
    public interface IPlayerMovement
    {
        void Configure(AbstractPlayerMediator player, PlayerMovementController playerMovementController);

        void Init();

        void Release();

        void Move();

        float GetSpeed();

        float GetDirection();
        bool GetSprinting();
    }
}
