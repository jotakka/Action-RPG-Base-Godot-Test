using Godot;

namespace ARPG.Shared;

public partial class CharacterAnimationController
{
    private AnimatedSprite2D _animationSprite;
    private AnimationPlayer _animationPlayer;
    public string _animation = "walk_down";

    public CharacterAnimationController(
        AnimatedSprite2D animatedSprite2D,
        AnimationPlayer animationPlayer)
    {
        _animationSprite = animatedSprite2D;
        _animationPlayer = animationPlayer;
    }

    public void SetWalkAnimation(Vector2 movementDirection)
    {
        _animation = AnimationType.Walk + "_" + GetAnimationDirection(movementDirection);
        _animationSprite.Play(_animation);
    }

    public void SetAttackAnimation(Vector2 movementDirection)
    {
        _animation = AnimationType.Attack + "_" + GetAnimationDirection(movementDirection);
        _animationPlayer.Play(_animation);
    }

    private static string GetAnimationDirection(Vector2 direction)
    {
        return direction switch
        {
            { X: > 0.0f } => AnimationDirection.Right,
            { X: < 0.0f } => AnimationDirection.Left,
            { Y: < 0.0f } => AnimationDirection.Up,
            { Y: > 0.0f } => AnimationDirection.Down,
            _ => AnimationDirection.Down, // Default to down
        };
    }

    private static class AnimationDirection
    {
        public const string Right = "right";
        public const string Left = "left";
        public const string Up = "up";
        public const string Down = "down";
    }

    private static class AnimationType
    {
        public const string Idle = "Idle";
        public const string Walk = "walk";
        public const string Attack = "attack";
    }
}
