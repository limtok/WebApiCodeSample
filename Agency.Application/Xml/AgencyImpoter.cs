using Agency.EntityFramework;
using AutoMapper;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Agency.Application
{
    public class AgencyImpoter : IAgencyImpoter
    {
        private readonly IMapper _mapper;
        private readonly IAgencyRepository _repository;
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(AgencyElement));

        public AgencyImpoter(
            IMapper mapper,
            IAgencyRepository repository
            )
        {
            _mapper = mapper;
            _repository = repository;
        }

        public Task ImportZipAsync(Stream stream)
        {
            using (var archive = new ZipArchive(stream, ZipArchiveMode.Read))
            {
                var entities = ParseAgencies(archive);
                return SaveAgencies(entities);
            }
        }

        private Task SaveAgencies(IList<Core.Agency> agencies)
        {
            return _repository.UpdateAsync(agencies);
        }

        private IList<Core.Agency> ParseAgencies(ZipArchive archive) 
        {
            var entities = new List<Core.Agency>();
            foreach (var entry in archive.Entries)
            {
                // ignore folder entry if any
                if (entry.Name.Length == 0)
                {
                    continue;
                }

                using (var stream = entry.Open())
                {
                    var entity = ParseAgency(stream);
                    entities.Add(entity);
                }
            }
            return entities;
        }

        private Core.Agency ParseAgency(Stream stream)
        {
            var agencyItem = _serializer.Deserialize(stream);
            var agency = _mapper.Map<Core.Agency>(agencyItem);
            return agency;
        }
    }
}
