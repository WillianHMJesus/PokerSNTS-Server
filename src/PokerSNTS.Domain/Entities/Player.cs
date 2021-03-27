﻿using FluentValidation;

namespace PokerSNTS.Domain.Entities
{
    public class Player : Entity
    {
        public Player(string name)
        {
            Name = name;
        }

        protected Player() { }

        public string Name { get; private set; }

        public override bool IsValid => Validate();

        private bool Validate()
        {
            var playerValidator = new PlayerValidator();
            var validationResult = playerValidator.Validate(this);
            SetValidationResult(validationResult);

            return validationResult.IsValid;
        }

        private class PlayerValidator : AbstractValidator<Player>
        {
            public PlayerValidator()
            {
                RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("O nome do jogador não foi informado.");
                RuleFor(x => x.Name).MaximumLength(50).WithMessage("O nome do jogador permite o número máximo de 50 caracters.");
            }
        }
    }
}