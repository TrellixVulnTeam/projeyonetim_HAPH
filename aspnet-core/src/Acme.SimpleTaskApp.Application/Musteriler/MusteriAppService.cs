﻿using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Acme.SimpleTaskApp.Musteriler.MusterilerDto;
using Acme.SimpleTaskApp.Projeler;
using Acme.SimpleTaskApp.Projeler.Customers.CustomersDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Projeler.Customers
{
    public class MusteriAppService : IMusteriAppService
    {
        private readonly IRepository<Musteri> _repository;
        private readonly IRepository<MusteriTalep> _talepRepository;
        public MusteriAppService(IRepository<Musteri> repository,IRepository<MusteriTalep> talepRepository)
        {
            _repository = repository;
            _talepRepository = talepRepository;
        }



        public async Task<List<MusteriDto>> GetMusteriList()
        {
            var entitylist = await _repository.GetAllListAsync();
            return entitylist.Select(e => new MusteriDto
            {
              
                MusteriAdi = e.MusteriAdi,
                Aciklama = e.Aciklama,
                Iletisim = e.Iletisim,
                UserId = e.UserId,
            }).ToList();
        }


        public async Task MusteriEkle(MusteriEkleDto input)
        {
            if (string.IsNullOrEmpty(input.MusteriAdi))
            {
                throw new UserFriendlyException("Müsteri Adı Boş Olamaz");
            }
            var entity = new Musteri
            {
                MusteriAdi = input.MusteriAdi,
                Aciklama = input.Aciklama,
                Iletisim = input.Iletisim,
            };
            await _repository.InsertAsync(entity);
        }



        //[AbpAuthorize(MyPermissions.UpdatingMusteri)]
        public async Task MusteriGuncelle(MusteriGuncelleDto input)
        {
            //if (!input.CustomerId.HasValue || input.CustomerId == 0)
            //{
            //    throw new System.Exception("Proje Bulunamadı");
            //}
            if (string.IsNullOrEmpty(input.MusteriAdi))
            {
                throw new UserFriendlyException("Müşteri Adı Boş Olamaz");
            }
            if (!input.MusteriId.HasValue || input.MusteriId == 0)
            {
                throw new UserFriendlyException("Geçersiz Müşteri Id");
            }

            var entity = await _repository.GetAsync(input.MusteriId.Value);
            entity.MusteriAdi = input.MusteriAdi;
            entity.Aciklama = input.Aciklama;
            entity.Iletisim = input.Iletisim;         

            await _repository.UpdateAsync(entity);
        }


        public async Task MusteriTalepEkle(MusteriTalepEkleDto input)
        {
            if (input.ProjeId == 0)
            {
                throw new UserFriendlyException("Geçersiz Proje Id");
            }
            var entity = new MusteriTalep
            {
                Talep  = input.MusteriTalep,
                BaslamaTarih = input.BaslamaTarihi,
            };


            await _talepRepository.InsertAsync(entity);

        }
        public async Task DeleteMusteri(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
