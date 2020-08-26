﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cine_matine_api;

namespace cine_matine_api.Migrations
{
    [DbContext(typeof(CineContext))]
    [Migration("20200826181651_FilmesNota")]
    partial class FilmesNota
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("cine_matine_api.Models.FilmeModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("Ano")
                        .HasColumnType("smallint");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diretor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GeneroId")
                        .HasColumnType("int");

                    b.Property<string>("ImageURI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkAlternativo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkDiretor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkImdb")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkYoutube")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeBrasil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeOriginal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Nota")
                        .HasColumnType("numeric(5,2)");

                    b.HasKey("Id");

                    b.HasIndex("GeneroId");

                    b.ToTable("Filme");
                });

            modelBuilder.Entity("cine_matine_api.Models.GeneroModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genero");
                });

            modelBuilder.Entity("cine_matine_api.Models.PessoaModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("cine_matine_api.Models.UsersModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("cine_matine_api.Models.FilmeModel", b =>
                {
                    b.HasOne("cine_matine_api.Models.GeneroModel", "Genero")
                        .WithMany()
                        .HasForeignKey("GeneroId");
                });

            modelBuilder.Entity("cine_matine_api.Models.PessoaModel", b =>
                {
                    b.HasOne("cine_matine_api.Models.UsersModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
