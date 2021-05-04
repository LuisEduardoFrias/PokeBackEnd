using AutoMapper;
//
using Entity.Dtos;
using Entity.Models;
//

namespace PokeApi.Mapper
{
    public class Configuration: Profile
    {
        public Configuration()
        {
            CreateMap<PaginationPokemon, PaginationPokemonDto>();

            CreateMap<Pokemon, PokemonDto>();

            CreateMap<Ability, AbilityDto>().ForMember(d => d.name, a => a.MapFrom(a => a.ability.name));
            CreateMap<Move, MoveDto>().ForMember(d => d.name, a => a.MapFrom(a => a.move.name));
            CreateMap<Type, TypeDto>().ForMember(d => d.name, a => a.MapFrom(a => a.type.name));

            CreateMap<PokemonDetail, PokemonDetailDto>()
                .ForMember(d => d.abilities, a => a.MapFrom(a => a.abilities))
                .ForMember(d => d.moves, a => a.MapFrom(a => a.moves))
                .ForMember(d => d.types, a => a.MapFrom(a => a.types))
                .ForMember(d => d.urlImage, a => a.MapFrom(a => a.sprites.versions.generationv.blackwhite.animated.front_default));
        }
    }
}
