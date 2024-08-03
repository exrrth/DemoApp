﻿using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<AppUser, MemberDto>() // map from AppUser to MemberDto
            .ForMember(d => d.Age, o => o.MapFrom(s => s.DateOfBirth.CalculateAge()))
            .ForMember(d => d.PhotoUrl,
            o => o.MapFrom(s => s.Photos.FirstOrDefault(x => x.IsMain)!.Url));  // d represents the destination member (PhotoUrl in MemberDto)
                                                                                // o represents the mapping options
                                                                                // s represents the source object (Photo)
        CreateMap<Photo, PhotoDto>(); // map from Photo to PhotoDto
    }
}
