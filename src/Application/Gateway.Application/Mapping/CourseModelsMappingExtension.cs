using Gateway.Application.Models.Courses;
using GrpcContracts = Courses.CourseService.Contracts;

namespace Gateway.Application.Mapping;

public static class CourseModelsMappingExtension
{
    public static CefrLevel MapToModel(this GrpcContracts.CefrLevel level)
    {
        return level switch
        {
            GrpcContracts.CefrLevel.A1 => CefrLevel.A1,
            GrpcContracts.CefrLevel.A2 => CefrLevel.A2,
            GrpcContracts.CefrLevel.B1 => CefrLevel.B1,
            GrpcContracts.CefrLevel.B2 => CefrLevel.B2,
            GrpcContracts.CefrLevel.C1 => CefrLevel.C1,
            GrpcContracts.CefrLevel.C2 => CefrLevel.C2,
            _ => throw new Exception($"Unknown level {level}"),
        };
    }

    public static GrpcContracts.CefrLevel MapToMessage(this CefrLevel level)
    {
        return level switch
        {
            CefrLevel.A1 => GrpcContracts.CefrLevel.A1,
            CefrLevel.A2 => GrpcContracts.CefrLevel.A2,
            CefrLevel.B1 => GrpcContracts.CefrLevel.B1,
            CefrLevel.B2 => GrpcContracts.CefrLevel.B2,
            CefrLevel.C1 => GrpcContracts.CefrLevel.C1,
            CefrLevel.C2 => GrpcContracts.CefrLevel.C2,
            _ => throw new Exception($"Unknown level {level}"),
        };
    }

    public static CourseState MapToModel(this GrpcContracts.CourseState state)
    {
        return state switch
        {
            GrpcContracts.CourseState.Published => CourseState.Published,
            GrpcContracts.CourseState.Unpublished => CourseState.Unpublished,
            GrpcContracts.CourseState.Draft => CourseState.Draft,
            _ => throw new Exception($"Unknown state {state}"),
        };
    }

    public static GrpcContracts.CourseState MapToMessage(this CourseState state)
    {
        return state switch
        {
            CourseState.Draft => GrpcContracts.CourseState.Draft,
            CourseState.Published => GrpcContracts.CourseState.Published,
            CourseState.Unpublished => GrpcContracts.CourseState.Unpublished,
            _ => throw new Exception($"Unknown state {state}"),
        };
    }
}