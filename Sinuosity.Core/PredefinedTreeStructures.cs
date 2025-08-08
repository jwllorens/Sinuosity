namespace Sinuosity
{
    public class TS_ProjectStreams : TreeStructure
    {
        public TS_ProjectStreams() : base("Streams")
        {

        }
    }
    public class TS_ProjectInfo : TreeStructure
    {
        public TS_ProjectInfo() : base("Properties")
        {

        }
    }
    public class TS_Stream : TreeStructure
    {
        public TS_Stream(string id) : base(id)
        {
            Attributes["formClass"] = "stream";
            Children.Add(new TS_StreamProperties("Properties"));
            Children.Add(new TreeStructure("Reaches"));
        }
    }
    public class TS_StreamProperties : TreeStructure
    {
        public TS_StreamProperties(string id) : base(id)
        {
            Children.Add(new TreeStructure("Alternate Name", ""));
            Children.Add(new TreeStructure("Alignment Name", ""));
            Children.Add(new TreeStructure("ToB Profile Name", ""));
            Children.Add(new TreeStructure("Bankfull Profile Name", ""));
            Children.Add(new TreeStructure("Thalweg Profile Name", ""));
        }
    }
    public class TS_Reach : TreeStructure
    {
        public TS_Reach(string id) : base(id)
        {
            Attributes["formClass"] = "reach";
            Attributes["order"] = "-1";
            Children.Add(new TS_ReachProperties("Properties"));
            Children.Add(new TS_ReachSectionData("Section Data"));
        }
    }

    public class TS_ReachProperties : TreeStructure
    {
        public TS_ReachProperties(string id) : base(id)
        {
            // Set Reach attributes
            Children.Add(new TreeStructure("Lateral Drainage Area", ""));
            Children.Add(new TreeStructure("Upstream Drainage Area", ""));
            Children.Add(new TreeStructure("Start Station", ""));
            Children.Add(new TreeStructure("End Station", ""));
            Children.Add(new TreeStructure("Alignment", ""));
        }
    }
    public class TS_ReachSectionData : TreeStructure
    {
        public TS_ReachSectionData(string id) : base(id)
        {
            // Set Reach attributes
            Attributes["formClass"] = "sectionData";
            Children.Add(new TreeStructure("Existing"));
            Children.Add(new TreeStructure("Target"));
            Children.Add(new TreeStructure("Design"));

        }
    }

    public class TS_ReachProfileData : TreeStructure
    {
        public TS_ReachProfileData(string id) : base(id)
        {
            Attributes["formClass"] = "profileData";
            Children.Add(new TreeStructure("Existing"));
            Children.Add(new TreeStructure("Target"));
            Children.Add(new TreeStructure("Design"));
        }
    }
    public class TS_ReachParticleData : TreeStructure
    {
        public TS_ReachParticleData(string id) : base(id)
        {
            Attributes["formClass"] = "profileData";
            Children.Add(new TreeStructure("Existing"));
            Children.Add(new TreeStructure("Target"));
            Children.Add(new TreeStructure("Design"));
        }
    }
}
