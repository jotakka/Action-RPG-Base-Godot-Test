using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;
using ARPG.Shared;
using ARPG.Util;

public partial class WalkAnimationComponent : Node2D
{
	[Export]
	public AnimationPlayer? AnimationPlayer;

	public AnimationDirection LastFacingDirection { get; private set; } = AnimationDirection.Down;

	public void PlayWalkAnimation(Vector2 direction)
	{
		var directionString = Helpers.GetAnimationDirectionString(direction);
		LastFacingDirection = directionString;
		AnimationPlayer?.Play(AnimationType.Walk + "_" + directionString);
	}

	public void PlayIdleAnimation()
	{
		AnimationPlayer?.Play(AnimationType.Idle + "_" + LastFacingDirection);
	}
}

